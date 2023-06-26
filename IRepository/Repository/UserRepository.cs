using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tracking_Task.Data;
using Tracking_Task.Models;

namespace Tracking_Task.IRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        public UserRepository(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public User Authenticate(string Email, string password)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == password);
            if (userInDb == null) return null;
            var books = _context.Books.Where(b => b.UserId == userInDb.Id).ToList();
          // userInDb.Id = books;
          //  if (books == null) return null;
            //jwt
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userInDb.Id.ToString()),
                    new Claim(ClaimTypes.Role,userInDb.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            userInDb.Token = tokenHandler.WriteToken(token);
            userInDb.Password = "";
            return userInDb;
        }

        public async Task<List<User>> GetAll()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

       

       

        public bool IsUniqueUser(string Email)
        {
            var User = _context.Users.FirstOrDefault(r => r.Email == Email);
            if (User == null)
                return true;
            else
                return false;
        }

       
        public User Register(string Name, string Address, string Age, string Email, string Password, string role)
        {
            User user = new User()
            {
                Name = Name,
                Address = Address,
                Age=Age,

                Password = Password,
                Email = Email,
                Role = "User"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
    }


