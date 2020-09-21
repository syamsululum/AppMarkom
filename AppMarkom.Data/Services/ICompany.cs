using AppMarkom.Data.Models;
using SolarCoffee.Services;
using System;
using System.Collections.Generic;

namespace AppMarkom.Data.Services
{
    public interface ICompany
    {
        List<m_company> GetCompanies();
        m_company GetCompanyById(int id);
        ServiceResponse<m_company> CreateCompany(m_company company);
        ServiceResponse<m_company> EditCompany(m_company company);
        ServiceResponse<bool> DeleteCompany(int id);
        List<m_company> GetCompanies(string code = "", string name = "", DateTime? createdDate = null, string created = "");
    }
}
