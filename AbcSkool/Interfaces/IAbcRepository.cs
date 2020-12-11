using System;
using System.Collections.Generic;
using System.Text;

namespace AbcSkool.Interfaces
{
    public interface IAbcRepository
    {
         IStudentRepository StudentRepository { get; set; }

    }
}
