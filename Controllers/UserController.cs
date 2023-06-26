using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracking_Task.Data;
using Tracking_Task.IRepository;
using Tracking_Task.Models;

namespace Tracking_Task.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        public UserController(IUserRepository userRepository, IEmailSender emailSender)
        {
            _userRepository = userRepository;
            _emailSender = emailSender;
        }
        [HttpPost("User")]
        public async Task<IActionResult> RegisterAsync([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Email != null)
                {
                    string emailBody = "<html><body style=\"font-family: Arial, sans-serif; background-image: background-repeat: no-repeat; background-size: cover; padding: 20px;\">"
                        + "<div style=\"background-color: #ffffff; border-radius: 10px; padding: 20px; border: 2px solid #336699;\">"
                        + $"<h2 style=\"color: #336699; margin-bottom: 20px;\">Dear {user.Name},</h2>"
                        + "<p style=\"color: #444; font-size: 16px;\">Welcome to our Website.</p>"

                        + "<p style=\"color: #444; font-size: 16px;\">Thank you and enjoy your experience with us!</p>"
                        + "<p style=\"color: #777; font-size: 14px;\">Best regards,</p>"

                        + "<p style=\"color: #444; font-size: 14px;\">You've successfully register to us</p>"
                        + "</div>"
                        + "</body></html>";

                    await _emailSender.SendEmailAsync(user.Email, " Welcome to our website", emailBody);
                }

                //var user = _mapper.Map<UserDTO, User>(userDTO);

                var isUniqueUser = _userRepository.IsUniqueUser(user.Name);
                if (!isUniqueUser) return BadRequest("User In Use");

                // user.Password = _encryptionRepository.EncryptPassword(user.Password);

                var UserInfo = _userRepository.Register(user.Name, user.Address, user.Age, user.Email, user.Password, user.Role);
                if (UserInfo == null) return BadRequest();
            }
            return Ok();
        }
        [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] UserVM userVM)
        {
            var user = _userRepository.Authenticate(userVM.Email, userVM.Password);

            if (user == null) return BadRequest("Wrong User/Password");
            return Ok(user);
        }
        //    public IActionResult Authenticate([FromBody] UserVM userVM)
        //    {
        //        var user = _userRepository.Authenticate(userVM.Email, userVM.Password);

        //        if (user == null)
        //        {
        //            return BadRequest("Wrong User/Password");
        //        }

        //        if (user.Role == "Admin")
        //        {
        //            // Perform actions specific to the admin user
        //            var allData = _userRepository.GetAll(); // Replace with the appropriate method to fetch all the data
        //            return Ok(allData);
        //        }
        //        else
        //        {
        //            // Perform actions for regular users
        //            return Ok(user);
        //        }
        //
        //   }
        [HttpGet]
        public IActionResult GetallUser()
            
        {
            var users = _userRepository.GetAllUser();
            return Ok(users);
        }
    }
}
