using AppMarkom.Data.Models;
using SolarCoffee.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMarkom.Data.Services
{
    public interface IEmployee
    {
        List<m_employee> GetEmployees();
        m_employee GetEmployeeById(int id);
        ServiceResponse<m_employee> CreateEmployee(m_employee model);
        ServiceResponse<m_employee> EditEmployee(m_employee model);
        ServiceResponse<bool> DeleteEmployee(int id);
        List<m_employee> GetEmployees(string code = "", string name = "", string companyName = "", DateTime? createdDate = null, string created = "");
    }
}
