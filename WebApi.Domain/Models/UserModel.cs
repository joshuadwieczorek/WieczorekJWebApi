using Global.Library.Common.Models;
using System;

namespace WebApi.Domain.Models
{
    public class UserModel : BaseModel
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public int Status { get; set; }
		public DateTime? LastLoginAt { get; set; }
		public string RegisteredBy { get; set; }
		public DateTime? RegisteredAt { get; set; }
	}
}