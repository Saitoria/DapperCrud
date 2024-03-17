using Dapper;
using DapperCrud.Data;
using DapperCrud.Interface;
using DapperCrud.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperCrud.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDbContext _context;
        public TeacherRepository(DapperDbContext context)
        {
            _context = context;
        }


        public async Task<bool> AddTeacher(Teacher teacher)
        {
            var result = await _context.CreateConnection.ExecuteAsync("insert into Teachers (TeacherID,FirstName,LastName,Gender,ContactNumber,Email,Country) values (@TeacherId,@FirstName,@LastName,@Gender,@ContactNumber,@Email,@Country)", teacher);
            return result > 0 ? true : false;    
        }

        public async Task<IEnumerable<Teacher>> DeleteTeacher(int teacherId)
        {
            var result = await _context.CreateConnection.ExecuteAsync("delete from Teachers where TeacherID = @Id", new
            {
                Id = teacherId
            });
            return await GetAllTeachers();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachers()
        {
            return await _context.CreateConnection.QueryAsync<Teacher>("select * from Teachers");
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _context.CreateConnection.QueryFirstAsync<Teacher>("select * from Teachers where TeacherID = @Id",
                new {Id = teacherId});
        }

        public async Task<bool> UpdateTeacher(Teacher teacher)
        {
            var result = await _context.CreateConnection.ExecuteAsync("update Teachers set FirstName = @FirstName,LastName = @LastName,Gender = @Gender,ContactNumber = @ContactNumber,Email = @Email,Country = @Country where TeacherID = @TeacherId", teacher);
            return result > 0 ? true : false;
        }
    }
}
