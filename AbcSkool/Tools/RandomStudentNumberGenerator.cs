using AbcSkool.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Tools
{
    public class RandomStudentNumberGenerator : IStudentNumberGenerator
    {
        public int Next(int min, int max)
        {
            Random random = new Random();

            int result = default;

            result = random.Next(min, max);

            return result;
        }
    }
}
