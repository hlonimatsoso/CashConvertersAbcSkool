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
    public class StudentSubjectsController : ControllerBase
    {

        IStudentSubjectService _service;
        IMapper _mapper;



        public StudentSubjectsController(IStudentSubjectService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }




        [HttpGet("")]
        public async Task<ActionResult> GetAllStudentsAsync()
        {
            try
            {
                List<StudentSubjects> result;

                result = await this._service.GetAllAsync() as List<StudentSubjects>;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Error getting all student subjects. {ex.Message} InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpGet("student/{Id:int}")]
        public async Task<ActionResult> GetAllSubjectForStudentIdAsync(int Id)
        {
            try
            {
                List<Subject> result;

                result = await this._service.GetAllSubjectsForStudentId(Id) as List<Subject>;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail:$"Failed to get subjects for student id {Id} & subject id . Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpPost("")]
        public async Task<ActionResult> AddStudentAsync(StudentSubjects pair)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            try
            {
                await this._service.AddAsync(pair);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to add subject id {pair.SubjectId} for student id {pair.StudentId}. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }

            return Ok();
        }




        [HttpDelete("student/{studentId:int}/subbject/{subjectId:int}")]
        public async Task<ActionResult> DeleteStudentSubjectAsync(int studentId,int subjectId)
        {
            
            try
            {
                await this._service.DeleteSubjectForStudent(studentId,subjectId);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to delete subject id {subjectId} for student Id '{studentId}'. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}.");
            }

            return Ok();
        }



    }




}
