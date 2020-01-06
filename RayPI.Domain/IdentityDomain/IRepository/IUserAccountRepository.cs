﻿using RayPI.Domain.IdentityDomain.Entity;
using RayPI.Domain.IRepository;

namespace RayPI.Domain.IdentityDomain.IRepository
{
    public interface IUserAccountRepository : IBaseRepository<UserAccountEntity>
    {
    }
}
