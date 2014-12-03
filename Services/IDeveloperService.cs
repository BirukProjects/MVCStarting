using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services
{
    public interface IDeveloperService
    {
        bool AddDeveloper(Developer developer);
        bool DeleteDeveloper(Developer developer);
        bool DeleteById(int id);
        bool EditDeveloper(Developer developer);
        Developer FindById(int id);
        List<Developer> GetAllDeveloper();
        List<Developer> FindBy(Expression<Func<Developer, bool>> predicate);
    }
}
