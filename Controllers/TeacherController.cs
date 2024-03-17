using Dapper;
using DapperCrud.Interface;
using DapperCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet("GetAllTeachers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            return Ok(teachers);
        }

        [HttpGet("GetTeacher/{teacherId})")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Teacher>> GetTeacher(int teacherId)
        {
            var teacher = await _teacherRepository.GetTeacherById(teacherId);
            return Ok(teacher);
        }

        [HttpPost("AddTeacher")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> AddTeacher(Teacher teacher)
        {
            var result = await _teacherRepository.AddTeacher(teacher);
            return Ok(result);
        }

        [HttpPut("UpdateTeacher")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> UpdateTeacher(Teacher teacher)
        {
            var result = await _teacherRepository.UpdateTeacher(teacher);
            return Ok(result);
        }

        [HttpDelete("DeleteTeacher/{teacherId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Teacher>>>DeleteTeacher(int teacherId)
        {
            var result = await _teacherRepository.DeleteTeacher(teacherId);
            return Ok(result);
        }

    }
}
