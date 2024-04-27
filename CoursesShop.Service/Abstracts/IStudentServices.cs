﻿using CoursesShop.Data.Entities;

namespace CoursesShop.Service.Abstracts
{
    public interface IStudentServices
    {
        public Task<List<Student>> GetAllAsync();
        public IQueryable<Student> GetAllAsQueryable();
        public Task<Student> GetByIdAsync(string Id);
        public Task AddStudent(Student student);
        public Task DeleteAsync(string Id);
        public Task<bool> IsEmailExistAsync(string Email);
        public Task<bool> IsIdExistAsync(string Id);
    }
}
