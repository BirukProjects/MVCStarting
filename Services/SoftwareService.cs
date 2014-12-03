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
    public class SoftwareService :ISoftwareService
    {
        private readonly  IUnitOfWork _unitOfWork;
      

       public SoftwareService(IUnitOfWork unitOfWork)
       {
           this._unitOfWork = unitOfWork;
       }
       #region Default Service Implementation
       public bool AddSoftware(Software software)
       {
           _unitOfWork.SoftwareRepository.Add(software);
           _unitOfWork.Save();
           return true;
           
       }
       public bool EditSoftware(Software software)
       {
           _unitOfWork.SoftwareRepository.Edit(software);
           _unitOfWork.Save();
           return true;

       }
         public bool DeleteSoftware(Software software)
        {
             if(software==null) return false;
           _unitOfWork.SoftwareRepository.Delete(software);
           _unitOfWork.Save();
           return true;
        }
       public  bool DeleteById(int id)
       {
           var Software = _unitOfWork.SoftwareRepository.FindById(id);
           if(Software==null) return false;
           _unitOfWork.SoftwareRepository.Delete(Software);
           _unitOfWork.Save();
           return true;
       }
       public List<Software> GetAllSoftware()
       {
           return _unitOfWork.SoftwareRepository.GetAll();
       } 
       public Software FindById(int id)
       {
           return _unitOfWork.SoftwareRepository.FindById(id);
       }
       public List<Software> FindBy(Expression<Func<Software, bool>> predicate)
       {
           return _unitOfWork.SoftwareRepository.FindBy(predicate);
       }
       #endregion
       
       public void Dispose()
       {
           _unitOfWork.Dispose();
           
       }
    }
}

         
      