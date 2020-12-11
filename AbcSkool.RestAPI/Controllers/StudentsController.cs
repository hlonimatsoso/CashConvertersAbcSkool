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
        public async Task<ActionResult> GetAllStudentsAsync()
        {
            try
            {
                List<Student> result;

                result = await this._service.GetAllAsync() as List<Student>;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Error getting all students. {ex.Message} InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetSingleStudentAsync(int Id)
        {
            try
            {
                Student result;

                result = await this._service.GetByIdAsync(Id) as Student;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail:$"Failed to get student id {Id}. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpPost("")]
        public async Task<ActionResult> AddStudentAsync(AddStudentDTO student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var s = _mapper.Map<Student>(student);

            try
            {
                await this._service.AddAsync(s);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to add student ({s.Name}). Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }

            return Ok();
        }





        [HttpPut("")]
        public async Task<ActionResult> UpdateStudentAsync(UpdateStudentDTO student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var s = _mapper.Map<Student>(student);

            try
            {
                await this._service.UpdateAsync(s);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to update student ({s.Name}). Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }

            return Ok();
        }







        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteStudentAsync(int Id)
        {
            
            try
            {
                await this._service.DeleteAsync(Id);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to delete student with ID '{Id}'. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}.");
            }

            return Ok();
        }



    }




}
