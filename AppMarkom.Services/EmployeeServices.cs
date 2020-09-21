using AppMarkom.Data;
using AppMarkom.Data.Models;
using AppMarkom.Data.Services;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMarkom.Services
{
    public class EmployeeServices : IEmployee
    {
        private readonly MarkomContext _ctx;

        public EmployeeServices(MarkomContext ctx)
        {
            _ctx = ctx;
        }

        public ServiceResponse<m_employee> CreateEmployee(m_employee model)
        {
            try
            {
                model.Code = GenerateCode();
                model.IsDelete = false;
                model.CreatedBy = "Admin";
                model.CreatedDate = DateTime.UtcNow;

                _ctx.m_employees.Add(model);
                _ctx.SaveChanges();

                return new ServiceResponse<m_employee>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Employee Created",
                    Data = model
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_employee>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public ServiceResponse<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = _ctx.m_employees.Find(id);
                employee.IsDelete = true;
                _ctx.m_employees.Update(employee);
                _ctx.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Employee Deleted",
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }

        public ServiceResponse<m_employee> EditEmployee(m_employee model)
        {
            try
            {
                model.UpdatedBy = "";
                model.UpdatedDate = DateTime.UtcNow;
                _ctx.m_employees.Update(model);
                _ctx.SaveChanges();

                return new ServiceResponse<m_employee>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Employee Created",
                    Data = model
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_employee>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public m_employee GetEmployeeById(int id)
        {
            return _ctx.m_employees.Find(id);
        }

        public List<m_employee> GetEmployees()
        {
            return _ctx.m_employees
                    .Include(x => x.MCompany)
                    .Where(x => x.IsDelete == false)
                    .Select(x => new m_employee
                    {
                        Id = x.Id,
                        Code = x.Code,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        MCompany = x.MCompany,
                        Email = x.Email,
                        IsDelete = x.IsDelete,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = x.UpdatedDate
                    }).ToList();
        }
        private string GenerateCode()
        {
            // get Max code
            string maxCode = GetEmployees().Max(x => x.Code);
            int code = 0;
            if (string.IsNullOrEmpty(maxCode))
            {
                code = 18032601;
            }
            else
            {
                string modifyCode = maxCode.Replace(".","");
                code = int.Parse(modifyCode);
                code++;
            }

            maxCode = Convert.ToString(code);
            string formattedSSN = maxCode.Insert(2, ".").Insert(5, ".").Insert(8, ".");
            return formattedSSN;
        }
    }
}
