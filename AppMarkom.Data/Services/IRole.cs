using AppMarkom.Data.Models;
using SolarCoffee.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMarkom.Data.Services
{
    public interface IRole
    {
        List<m_role> GetRoles();
        ServiceResponse<m_role> CreateRole(m_role role);
        ServiceResponse<m_role> EditRole(m_role role);
        m_role GetRoleById(int id);
        ServiceResponse<bool> DeleteRole(int id);
        List<m_role> GetRoles(string code = "", string name = "", DateTime? createdDate = null, string created = "");
    }
}
