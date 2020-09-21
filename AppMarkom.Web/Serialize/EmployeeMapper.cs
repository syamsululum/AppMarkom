using AppMarkom.Data.Models;
using AppMarkom.Web.ViewModels.employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Serialize
{
    public static class EmployeeMapper
    {
        public static employeeViewModel SerializeEmployee(m_employee model)
        {
            return new employeeViewModel
            {
                Id = model.Id,
                Code = model.Code,
                FirstName   = model.FirstName,
                LastName    = model.LastName,
                MCompany   = CompanyMapper.SerializeCompany(model.MCompany),
                Email       = model.Email,
                IsDelete    = model.IsDelete,
                CreatedBy   = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedBy   = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate
            };
        }

        public static m_employee SerializeEmployee(employeeViewModel model)
        {
            return new m_employee
            {
                Id = model.Id,
                Code = model.Code,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MCompany = CompanyMapper.SerializeCompany(model.MCompany),
                Email = model.Email,
                IsDelete = model.IsDelete,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate
            };
        }
    }
}
