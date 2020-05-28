using System;
using System.Threading.Tasks;
using ApplicationShared;
using Core;
using Microsoft.EntityFrameworkCore;


namespace Application
{
    public class UserController : IUser
    {
        public async Task<bool> Login(string username, string password)
        {
            using var context = new ReservationContext();
            var foundUser = await context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
            if (foundUser?.Password.Equals(password) ?? false)
            {
                foundUser.HasCurrentSession = true;
                context.SaveChanges();

                return foundUser?.HasCurrentSession ?? false;
            }

            return false;
        }

        public async Task<bool> Logout(string username)
        {
            using var context = new ReservationContext();

            var currentUser = await context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));

            if (currentUser == null) return false;

            currentUser.HasCurrentSession = false;

            context.SaveChanges();

            //Default for HasCurrentSession should be false
            return !currentUser.HasCurrentSession;
        }

        public Task<bool> CreateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUser(User userToRemove)
        {
            throw new NotImplementedException();
        }
    }
}