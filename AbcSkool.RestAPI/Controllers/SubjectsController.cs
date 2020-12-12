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
    public class SubjectsController : ControllerBase
    {

        ISubjectService _service;
        IMapper _mapper;



        public SubjectsController(ISubjectService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }




        [HttpGet("")]
        public async Task<ActionResult> GetAllSubjectsAsync()
        {
            try
            {
                List<Subject> result;

                result = await this._service.GetAllAsync() as List<Subject>;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Error getting all subjects. {ex.Message} InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpGet("{Id:int}")]
        public async Task<ActionResult> GetSingleSubjectAsync(int Id)
        {
            try
            {
                Subject result;

                result = await this._service.GetByIdAsync(Id) as Subject;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(detail:$"Failed to get subject id {Id}. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }
        }





        [HttpPost("")]
        public async Task<ActionResult> AddSubjectAsync(AddSubjectDTO subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var s = _mapper.Map<Subject>(subject);

            try
            {
                await this._service.AddAsync(s);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to add subject ({s.SubjectName}). Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }

            return Ok();
        }





        [HttpPut("")]
        public async Task<ActionResult> UpdateSubjectAsync(UpdateSubjectDTO subject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var s = _mapper.Map<Subject>(subject);

            try
            {
                await this._service.UpdateAsync(s);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to update subject ({s.SubjectName}). Error: {ex.Message}. InnerException: {ex.InnerException?.Message}");
            }

            return Ok();
        }







        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteSubjectAsync(int Id)
        {
            
            try
            {
                await this._service.DeleteAsync(Id);

                await this._service.SaveAsync();
            }
            catch (Exception ex)
            {
                return Problem(detail: $"Failed to delete subject with ID '{Id}'. Error: {ex.Message}. InnerException: {ex.InnerException?.Message}.");
            }

            return Ok();
        }



    }




}
