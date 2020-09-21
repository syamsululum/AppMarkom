using AppMarkom.Data.Models;
using AppMarkom.Web.ViewModels.company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Serialize
{
    public static class CompanyMapper
    {
        public static companyViewModel SerializeCompany(m_company company)
        {
            return new companyViewModel
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Email = company.Email,
                IsDelete = company.IsDelete,
                CreatedBy = company.CreatedBy,
                CreatedDate = company.CreatedDate,
                UpdatedBy = company.UpdatedBy,
                UpdatedDate = company.UpdatedDate
            };
        }
        public static m_company SerializeCompany(companyViewModel company)
        {
            return new m_company
            {
                Id = company.Id,
                Code = company.Code,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Email = company.Email,
                IsDelete = company.IsDelete,
                CreatedBy = company.CreatedBy,
                CreatedDate = company.CreatedDate,
                UpdatedBy = company.UpdatedBy,
                UpdatedDate = company.UpdatedDate
            };
        }
    }
}
