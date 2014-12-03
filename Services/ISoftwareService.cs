using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Services
{
    public interface ISoftwareService
    {
        bool AddSoftware(Software software);
        bool DeleteSoftware(Software software);
        bool DeleteById(int id);
        bool EditSoftware(Software software);
        Software FindById(int id);
        List<Software> GetAllSoftware();
        List<Software> FindBy(Expression<Func<Software, bool>> predicate);
    }
}
