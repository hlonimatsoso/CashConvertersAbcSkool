using AbcSkool.Models;
using AbcSkool.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbcSkool.RestAPI
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Object, Student>();

            CreateMap<Student, AddStudentDTO>().ReverseMap();

            CreateMap<Student, UpdateStudentDTO>().ReverseMap();


        }
    }
}
