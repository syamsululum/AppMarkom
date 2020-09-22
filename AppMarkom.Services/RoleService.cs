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
    public class RoleService : IRole
    {
        private readonly MarkomContext _ctx;

        public RoleService(MarkomContext ctx)
        {
            _ctx = ctx;
        }
        public ServiceResponse<m_role> CreateRole(m_role role)
        {
            try
            {
                role.Code = "RO" + GenCode();
                role.IsDelete = false;
                role.CreatedBy = "Administrator";
                role.CreatedDate = DateTime.UtcNow;
                _ctx.m_roles.Add(role);
                _ctx.SaveChanges();

                return new ServiceResponse<m_role>
                {
                    IsSuccess = true,
                    Time = DateTime.UtcNow,
                    Message = "Role Created",
                    Data = role
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_role>
                {
                    IsSuccess = false,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    Data = null
                };
            }
        }

        public ServiceResponse<bool> DeleteRole(int id)
        {
            try
            {
                var role = _ctx.m_roles.Find(id);
                role.IsDelete = true;
                _ctx.m_roles.Update(role);
                _ctx.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Message = "Role Deleted",
                    Time = DateTime.UtcNow,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }

        public ServiceResponse<m_role> EditRole(m_role role)
        {
            role.UpdatedBy = "Administrator";
            role.UpdatedDate = DateTime.UtcNow;
            try
            {
                _ctx.m_roles.Update(role);
                _ctx.SaveChanges();

                return new ServiceResponse<m_role>
                {
                    IsSuccess = true,
                    Message = "Role Deleted",
                    Time = DateTime.UtcNow,
                    Data = role
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<m_role>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = null
                };
            }
        }

        public m_role GetRoleById(int id)
        {
            return _ctx.m_roles.Find(id);
        }

        public List<m_role> GetRoles()
        {
            return _ctx.m_roles.Where(x => x.IsDelete == false).ToList();
        }

        public List<m_role> GetRoles(string code = "", string name = "", DateTime? createdDate = null, string created = "")
        {
            var query = (from o in _ctx.m_roles.Where(x => x.IsDelete == false).ToList() select o);
            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(q => q.Code == code);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(q => q.Name == name);
            }
            if (createdDate != null)
            {
                query = query.Where(q => q.CreatedDate == createdDate);
            }
            if (!string.IsNullOrEmpty(created))
            {
                query = query.Where(q => q.CreatedBy == created);
            }

            return query.ToList();
        }

        private string GenCode()
        {
            string maxCode = GetRoles().Max(x => x.Code);
            if (string.IsNullOrEmpty(maxCode))
            {
                maxCode = "RO0001";
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
