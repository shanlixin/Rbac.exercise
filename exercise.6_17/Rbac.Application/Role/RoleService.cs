using AutoMapper;
using Rbac.Entity;
using Rbac.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class RoleService: BaseService<Role, Role>,IRoleService
    {
        public RoleService(IRoleRepository role, IMapper mapper) : base(role, mapper)
        {
            Role = role;
        }

        public IRoleRepository Role { get; }
    }
}
