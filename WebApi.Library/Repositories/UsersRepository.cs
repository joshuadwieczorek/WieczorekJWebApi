using Global.Library.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApi.Domain.Models;
using Dapper;
using System.Linq;

namespace WebApi.Library.Repositories
{
    public class UsersRepository : BaseLogger<UsersRepository>, IUsersRepository
    {
        private readonly string _connectionString;


        public UsersRepository(
              ILogger<UsersRepository> logger
            , Bugsnag.IClient bugSnag
            , IConfiguration configuration) : base(logger, bugSnag)
        {
            _connectionString = configuration.GetConnectionString("Users");
        }


        public async Task<UserModel> Read(Guid userId)
        {
            try
            {
                var paramaters = new
                {
                    @UserId = userId
                };

                var connection = new SqlConnection(_connectionString);
                connection.Open();
                var user = await connection.QueryFirstOrDefaultAsync<UserModel>("[dbo].[UsersRead]", paramaters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return user;
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }



        public async Task<IEnumerable<UserModel>> Read()
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                var users = await connection.QueryAsync<UserModel>("[dbo].[UsersRead]", commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return users.ToList();
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }


        public async Task<UserModel> Create(UserModel user)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                await connection.ExecuteAsync("[dbo].[UsersCreate]", user, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return user;
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }


        public async Task<UserModel> Update(UserModel user)
        {
            try
            {
                var connection = new SqlConnection(_connectionString);
                connection.Open();
                await connection.ExecuteAsync("[dbo].[UsersUpdate]", user, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
                return user;
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }


        public async Task Delete(Guid userId)
        {
            try
            {
                var paramaters = new
                {
                    @UserId = userId
                };

                var connection = new SqlConnection(_connectionString);
                connection.Open();
                await connection.ExecuteAsync("[dbo].[UsersDelete]", paramaters, commandType: System.Data.CommandType.StoredProcedure);
                connection.Close();
            }
            catch (Exception e)
            {
                LogError(e);
                throw;
            }
        }
    }
}