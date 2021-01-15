using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Library.Repositories
{
    public interface IUsersRepository
    {
        Task<UserModel> Create(UserModel user);
        Task Delete(Guid userId);
        Task<IEnumerable<UserModel>> Read();
        Task<UserModel> Read(Guid userId);
        Task<UserModel> Update(UserModel user);
    }
}