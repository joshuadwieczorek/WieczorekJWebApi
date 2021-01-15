using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;

namespace WebApi.Library.Services
{
    public interface IUsersService
    {
        Task<User> Create(User user);
        Task Delete(Guid userId);
        Task<IEnumerable<User>> Read();
        Task<User> Read(Guid userId);
        Task<User> Update(User user);
    }
}