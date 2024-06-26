﻿using CoursesShop.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace CoursesShop.Service.EntityServices.Interfaces
{
    public interface ICourseServices
    {
        public Task<List<Course>> GetAllAsync();
        public Task<List<Course>> GetByTeacherIdAsync(string teacherId);
        public IQueryable<Course> GetAllAsQueryable();
        public IQueryable<Course> FillterAllAsQueryable(string search);
        public Course GetById(string Id);
        public Task AddAsync(Course course, IFormFile? Image);
        public Task UpdateAsync(Course course, IFormFile? Image);
        public Task UpdateRating(string id, double evalution, UpdateRatingType type);
        public bool IsIdExist(string id);
        public bool IsCourseIdToTeacherId(string courseId, string teacherId);
        public Task DeleteAsync(string Id);
    }

    public enum UpdateRatingType : byte
    {
        Add = 0,
        Update = 1,
        Delete = 2
    }
}
