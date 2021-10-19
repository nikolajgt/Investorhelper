using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Restful.Models;
using Restful.Models.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Repositorys
{
    public class User : IUser
    {
        private readonly string _dbName = "InvestorHelper";
        private readonly string _dbCollection = "UserData";

        private readonly string key;

        private readonly IMongoCollection<UserLogin> _repository;


        //Dependency injection og oprettelse af forbindelese til DB
        public User(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDb"));
            var database = client.GetDatabase(_dbName);
            _repository = database.GetCollection<UserLogin>(_dbCollection);
            this.key = config.GetSection("JwtKey").ToString();
        }


        // Logic for nyoprettet users, checker for om felterne er udfyldt
        // Bruger GUID id som ID
        public async Task<UserLogin> CreateUser(string username, string password, string fullname, string email)
        {
            var NewUser = new UserLogin
            {
                _Id = Guid.NewGuid(),
                Username = username,
                Password = password,
                Fullname = fullname,
                Email = email
            };
            if (NewUser.Username == null || NewUser.Password == null || NewUser.Fullname == null || NewUser.Email == null)
                return null;

            await _repository.InsertOneAsync(NewUser);

            return NewUser;
        }


        // JWT Login logic som searcher DB for Username and Password
        // Laver det om til en JWT. Indholder creation time, expire time.
        public string Authenticate(string username, string password)
        {
            var user = _repository.Find(x => x.Username == username && x.Password == password).FirstOrDefault();

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
