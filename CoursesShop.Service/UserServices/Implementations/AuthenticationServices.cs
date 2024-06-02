using CoursesShop.Data.Helpers;
using CoursesShop.Data.Identity;
using CoursesShop.Data.Results;
using CoursesShop.Infrastructure.Interfaces;
using CoursesShop.Service.UserServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CoursesShop.Service.UserServices.Implementations
{
    public sealed class AuthenticationServices(SignInManager<ApplicationUser> signInManager,
                                               UserManager<ApplicationUser> userManager,
                                               JwtSettings jwtSettings,
                                               IRefershTokenRepository refershTokenRepository) : IAuthenticationServices
    {
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IRefershTokenRepository _refershTokenRepository = refershTokenRepository;


        public async Task<JwtAuthResult> SignupAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                var (token, accessToken, userType) = await GetToken(user);
                var refershtoken = GetRefreshToken(user.UserName, userType);

                var userRefreshToken = new UserRefreshToken
                {
                    AddedTime = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                    IsUsed = true,
                    IsRevoked = false,
                    JwtId = token.Id,
                    RefreshToken = refershtoken.TokenString,
                    Token = accessToken,
                    ApplicationUserId = user.Id
                };
                await _refershTokenRepository.AddAsync(userRefreshToken);


                return new JwtAuthResult()
                {
                    AccessToken = accessToken,
                    refreshToken = refershtoken
                };
            }
            return null;
        }




        public async Task<JwtAuthResult> GetRefreshTokenAsync(ApplicationUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken)
        {
            var (jwtSecurityToken, newToken, userType) = await GetToken(user);

            var refreshTokenResult = new RefreshToken
            {
                UserName = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserName").Value,
                UserType = userType,
                TokenString = refreshToken,
                ExpireAt = (DateTime)expiryDate
            };

            var response = new JwtAuthResult
            {
                AccessToken = newToken,
                refreshToken = refreshTokenResult
            };

            return response;

        }

        public async Task<string> ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(_jwtSettings.GenerateSymmetricKey()),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };
            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                if (validator == null)
                {
                    return "InvalidToken";
                }

                return "NotExpired";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public async Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("AlgorithmIsWrong", null);
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return ("TokenIsNotExpired", null);
            }

            //Get User

            string userId = jwtToken.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            var userRefreshToken = refershTokenRepository.GetTableNoTracking()
                                             .FirstOrDefault(x => x.Token == accessToken &&
                                                                     x.RefreshToken == refreshToken &&
                                                                     x.ApplicationUserId == userId);
            if (userRefreshToken == null)
            {
                return ("RefreshTokenIsNotFound", null);
            }

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await refershTokenRepository.UpdateAsync(userRefreshToken);
                return ("RefreshTokenIsExpired", null);
            }
            var expirydate = userRefreshToken.ExpiryDate;
            return (userId, expirydate);
        }

        public JwtSecurityToken ReadJWTToken(string accessToken)
        {
            return new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
        }

        private async Task<(JwtSecurityToken, string, string)> GetToken(ApplicationUser applicationUser)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),
                    new Claim(ClaimTypes.Name,applicationUser.UserName),
                    new Claim(ClaimTypes.Email,applicationUser.Email),
                    new Claim("TypeId",applicationUser.TypeId is null ? applicationUser.Id : applicationUser.TypeId)
                };
            var roles = await _userManager.GetRolesAsync(applicationUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var token = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                             audience: _jwtSettings.Audience,
                                             claims: claims,
                                             expires: DateTime.UtcNow.AddMonths(_jwtSettings.AccessTokenExpireDate),
                                             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_jwtSettings.GenerateSymmetricKey())
                                                                                        , SecurityAlgorithms.HmacSha256Signature));

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return (token, accessToken, roles.FirstOrDefault());
        }
        private RefreshToken GetRefreshToken(string username, string userType)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddMonths(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                UserType = userType,
                TokenString = GenerateRefreshToken()
            };
            return refreshToken;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
