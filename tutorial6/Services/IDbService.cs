using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tutorial6.Models;

namespace tutorial6.Services
{
    public interface IDbService
    {
        Student GetStudentByIndex(string Index);
    }
}