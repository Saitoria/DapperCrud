using DapperCrud.Models;
using System.Data;

namespace DapperCrud.Interface
{
    public interface ITeacherRepository
    {       
        Task<IEnumerable<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
        Task<bool> AddTeacher(Teacher teacher);
        Task<bool> UpdateTeacher(Teacher teacher);
        Task<IEnumerable<Teacher>> DeleteTeacher(int teacherId);
    }
}