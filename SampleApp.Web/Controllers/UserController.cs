using System.Collections.Generic;
using System.Web.Http;
using SampleApp.Business;
using SampleApp.Models;

namespace SampleApp.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        // GET api/user
        public IEnumerable<User> Get(string q = null, string sort = null, bool desc = false, int? limit = null,
            int offset = 0)
        {
            return _userService.GetUsers(q, sort, desc, limit,
                offset);
        }

        // GET api/user/5
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        // POST api/user
        public void Post(User user)
        {
            _userService.CreateUser(user);
        }

        // PUT api/user/5
        public void Put(int id, User user)
        {
            _userService.UpdateUser(id, user);
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
