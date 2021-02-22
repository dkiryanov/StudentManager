using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;

namespace StudentManager
{
    class Program
    {
        static void Main(string[] args)
        {
            ImporterService s = new ImporterService();

            s.GetCourseInfoDtos();
        }
    }
}
