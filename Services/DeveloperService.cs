using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.UnitOfWork;
using Services;

namespace Services
{
    public class DeveloperService :IDeveloperService
    {
        private readonly  IUnitOfWork _unitOfWork;
      

       public DeveloperService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddDeveloper(Developer developer)
       {
           _unitOfWork.DeveloperRepository.Add(developer);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditDeveloper(Developer developer)
       {
           _unitOfWork.DeveloperRepository.Edit(developer);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteDeveloper(Developer developer)
        {
             if(developer==null) return false;
           _unitOfWork.DeveloperRepository.Delete(developer);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var developer = _unitOfWork.DeveloperRepository.FindById(id);
           if(developer==null) return false;
           _unitOfWork.DeveloperRepository.Delete(developer);
           _unitOfWork.Save();
           return true;
       }
       public List<Developer> GetAllDeveloper()
       {
           return _unitOfWork.DeveloperRepository.GetAll();
       } 
       public Developer FindById(int id)
       {
           return _unitOfWork.DeveloperRepository.FindById(id);
       }
       public List<Developer> FindBy(Expression<Func<Developer, bool>> predicate)
       {
           return _unitOfWork.DeveloperRepository.FindBy(predicate);
       }
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
    }
}

         
      