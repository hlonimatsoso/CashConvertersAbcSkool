using AbcSkool.Interfaces;
using AbcSkool.Models;
using AbcSkool.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbcSkool.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        IStudentService _service;
        IMapper _mapper;

        public StudentsController(IStudentService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public List<Student> GetAllStudents()
        {
            List<Student> result;

            result = this._service.GetAll() as List<Student>;

            return result;
        }


        [HttpGet("{Id:int}")]
        public Student GetSingleStudent(int Id)
        {
            Student result;

            result = this._service.GetById(Id) as Student;

            return result;
        }


        [HttpPost("")]
        public void AddStudent(AddStudentDTO student)
        {
            var s = _mapper.Map<Student>(student);

            this._service.Insert(s);

            this._service.Save();
        }

        [HttpPut("")]
        public void UpdateStudent(UpdateStudentDTO student)
        {
            var s = _mapper.Map<Student>(student);

            this._service.Update(s);

            this._service.Save();
        }

        [HttpDelete("{Id:int}")]
        public void DeleteStudent(int Id)
        {
            this._service.Delete(Id);

            this._service.Save();
        }
    }


}
