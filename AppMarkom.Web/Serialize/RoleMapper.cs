using AppMarkom.Data.Models;
using AppMarkom.Web.ViewModels.role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMarkom.Web.Serialize
{
    public static class RoleMapper
    {
        public static roleViewModel SerializeRole(m_role role)
        {
            return new roleViewModel
            {
                Id = role.Id,
                Code = role.Code,
                Name = role.Name,
                Description = role.Description,
                IsDelete = role.IsDelete,
                CreatedBy = role.CreatedBy,
                CreatedDate = role.CreatedDate,
                UpdatedBy = role.UpdatedBy,
                UpdatedDate = role.UpdatedDate
            };
        }

        public static m_role SerializeRole(roleViewModel role)
        {
            return new m_role
            {
                Id = role.Id,
                Code = role.Code,
                Name = role.Name,
                Description = role.Description,
                IsDelete = role.IsDelete,
                CreatedBy = role.CreatedBy,
                CreatedDate = role.CreatedDate,
                UpdatedBy = role.UpdatedBy,
                UpdatedDate = role.UpdatedDate
            };
        }
    }
}
