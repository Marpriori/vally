﻿using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repository;

namespace ProjetoModeloDDD.Infra.Data.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
    }
}
