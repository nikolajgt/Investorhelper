using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restful.Models.DTO
{
    public class UserLoginDTO
    {
        [BsonId]

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
