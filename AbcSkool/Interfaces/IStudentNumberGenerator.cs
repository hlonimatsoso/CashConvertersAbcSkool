using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Interfaces
{
    public interface IStudentNumberGenerator
    {
        int Next(int min, int max);
    }
}
