using Global.Library.Common.Contracts.Api;
using System;
using Newtonsoft.Json;

namespace WebApi.Domain.Contracts
{
    public class User : BaseContract
    {
        [JsonProperty("userId")]
        public Guid UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("lastLoginAt")]
        public DateTime? LastLoginAt { get; set; }

        [JsonProperty("registeredBy")]
        public string RegisteredBy { get; set; }

        [JsonProperty("registeredAt")]
        public DateTime? RegisteredAt { get; set; }
    }
}