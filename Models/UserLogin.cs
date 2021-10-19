using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Models
{
    public record UserLogin
    {
        [BsonId]
        public Guid _Id { get; set; }
        [BsonElement("Username")]
        public string Username { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public bool LoggedIn { get; set; }
    }
}


