﻿using System;
using System.Collections.Generic;
using System.Text;
using RayPI.Domain.IdentityDomain.Entity;

namespace RayPI.Domain.IdentityDomain
{
    public interface IIdentityDomainService
    {
        void Register(UserAccountEntity userAccountEntity);

        long Login(string userName, string pwdHash);
        List<RoleEntity> GetRolesByUid(long id);
        void SetPermissions(long roleId, List<string> permissionCodes);
        List<string> GetPermissionsByRoleCodes(string[] roleIds);
        void DeleteUser(long uid);
    }
}
