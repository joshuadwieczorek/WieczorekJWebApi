using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using Global.Library.Common.Contracts.Data;
using WebApi.Domain.Contracts;
using WebApi.Domain.Models;

namespace WebApi.Library.Data.Translators
{
    public class UsersTranslator : ITranslateContractToModel<User, UserModel>, ITranslateModelToContract<UserModel, User>
    {
        public UserModel Translate(User contract)
        {
            if (contract == null)
                throw new ArgumentException(nameof(contract));

            return new UserModel
            {
                UserId = contract.UserId,
                Username = contract.Username,
                FirstName = contract.FirstName,
                LastName = contract.LastName,
                EmailAddress = contract.EmailAddress,
                Status = contract.Status,
                LastLoginAt = contract.LastLoginAt,
                RegisteredAt = contract.LastLoginAt,
                RegisteredBy = contract.RegisteredBy,
                CreatedAt = contract.CreatedAt,
                CreatedBy = contract.CreatedBy,
                UpdatedAt = contract.UpdatedAt,
                UpdatedBy = contract.UpdatedBy
            };
        }


        public IEnumerable<UserModel> Translate(IEnumerable<User> contracts)
        {
            if (contracts == null)
                throw new ArgumentException(nameof(contracts));

            var models = new ConcurrentBag<UserModel>();
            
            Parallel.ForEach<User>(contracts, (c) =>
            {
                UserModel model = Translate(c);
                if (model != null)
                    models.Add(model);
            });

            return models.ToList();
        }


        public User Translate(UserModel model)
        {
            if (model == null)
                throw new ArgumentException(nameof(model));

            return new User
            {
                UserId = model.UserId,
                Username = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                Status = model.Status,
                LastLoginAt = model.LastLoginAt,
                RegisteredAt = model.LastLoginAt,
                RegisteredBy = model.RegisteredBy,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy,
                UpdatedAt = model.UpdatedAt,
                UpdatedBy = model.UpdatedBy
            };
        }


        public IEnumerable<User> Translate(IEnumerable<UserModel> models)
        {
            if (models == null)
                throw new ArgumentException(nameof(models));

            var contracts = new ConcurrentBag<User>();

            Parallel.ForEach<UserModel>(models, (c) =>
            {
                User contract = Translate(c);
                if (contract != null)
                    contracts.Add(contract);
            });

            return contracts.ToList();
        }
    }
}