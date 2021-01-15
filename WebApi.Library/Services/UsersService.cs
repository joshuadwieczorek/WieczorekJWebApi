using Global.Library.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Domain.Contracts;
using WebApi.Library.Repositories;
using WebApi.Library.Data.Translators;

namespace WebApi.Library.Services
{
    public class UsersService : BaseLogger<UsersService>, IUsersService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsersRepository _usersRepository;
        private readonly UsersTranslator _usersTranslator;


        public UsersService(
              ILogger<UsersService> logger
            , Bugsnag.IClient bugSnag
            , IConfiguration configuration
            , IUsersRepository usersRepository) : base(logger, bugSnag)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
            _usersTranslator = new UsersTranslator();
        }


        public async Task<User> Read(Guid userId)
        {
            try
            {
                // Check any user permissions necessary then read.
                var userModel = await _usersRepository.Read(userId);
                return _usersTranslator.Translate(userModel);
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }



        public async Task<IEnumerable<User>> Read()
        {
            try
            {
                // Check any user permissions necessary then read.
                var userModels = await _usersRepository.Read();
                return _usersTranslator.Translate(userModels);
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }


        public async Task<User> Create(User user)
        {
            try
            {
                // Check any user permissions necessary then create.
                var userModel = _usersTranslator.Translate(user);
                await _usersRepository.Create(userModel);
                return user;
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }


        public async Task<User> Update(User user)
        {
            try
            {
                // Check any user permissions necessary then perform the update.
                var userModel = _usersTranslator.Translate(user);
                await _usersRepository.Update(userModel);
                return user;
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }


        public async Task Delete(Guid userId)
        {
            try
            {
                // Check any user permissions necessary then perform the delete.
                await _usersRepository.Delete(userId);
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }
    }
}