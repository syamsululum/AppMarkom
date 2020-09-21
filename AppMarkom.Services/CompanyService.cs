using AppMarkom.Data;
using AppMarkom.Data.Models;
using AppMarkom.Data.Services;
using SolarCoffee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMarkom.Services
{
    public class CompanyService : ICompany
    {
        private readonly MarkomContext _ctx;

        public CompanyService(MarkomContext ctx)
        {
            _ctx = ctx;
        }
        public ServiceResponse<m_company> CreateCompany(m_company company)
        {
            try
            {
                company.Code = "CP" + GenerateCode();
                company.IsDelete = false;
                company.CreatedBy = "";
                company.CreatedDate = DateTime.UtcNow;

                _ctx.m_companies.Add(company);
                _ctx.SaveChanges();

                return new ServiceResponse<m_company>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Company Created",
                    Data = company
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_company>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = null
                };
            }

        }

        public ServiceResponse<bool> DeleteCompany(int id)
        {
            try
            {
                var company = _ctx.m_companies.Find(id);
                company.IsDelete = true;
                company.UpdatedBy = "Admin";
                company.UpdatedDate = DateTime.UtcNow;
                _ctx.m_companies.Update(company);
                _ctx.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = DateTime.UtcNow,
                    Message = "Company Deleted",
                    IsSuccess = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }

        public ServiceResponse<m_company> EditCompany(m_company company)
        {
            try
            {
                _ctx.m_companies.Update(company);
                _ctx.SaveChanges();

                return new ServiceResponse<m_company>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Company Updated",
                    Data = company
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_company>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public List<m_company> GetCompanies()
        {
            return _ctx.m_companies.Where(x => x.IsDelete == false).ToList();
        }

        public List<m_company> GetCompanies(string code = "", string name = "", DateTime? createdDate = null, string created = "")
        {
            //if (string.IsNullOrEmpty(code) & string.IsNullOrEmpty(name) & createdDate != null & string.IsNullOrEmpty(created))
            //{
                return _ctx.m_companies
                    .Where(x => x.Code == code)
                    .Where(x => x.Name == name)
                    .Where(x => x.CreatedDate == createdDate)
                    .Where(x => x.CreatedBy == created)
                    .ToList();
            //}
        }

        public m_company GetCompanyById(int id)
        {
            return _ctx.m_companies.Find(id);
        }

        private string GenerateCode()
        {
            // get Max code
            string maxCode = GetCompanies().Max(x => x.Code);
            if (string.IsNullOrEmpty(maxCode))
            {
                maxCode = "CP0001";
            }
            string extract = string.Empty;
            int val;
            // extract number of code
            for (int i = 0; i < maxCode.Length; i++)
            {
                if (Char.IsDigit(maxCode[i]))
                    extract += maxCode[i];
            }
            // generate new number of code
            if (extract.Length > 0)
            {
                val = int.Parse(extract);
                val++;
                string invoiceNo = val.ToString().PadLeft(4, '0');
                return invoiceNo;
            }
            return "";
        }
    }
}
