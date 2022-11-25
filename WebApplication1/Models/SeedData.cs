using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AllDBContext(serviceProvider.GetRequiredService<DbContextOptions<AllDBContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }


                context.Users.AddRange(
                    new Users
                    {
                        Login = "user1@user.com",
                        Password = "qwerty123",
                        Role = "Admin"
                    },
                     new Users
                     {
                         Login = "user2@user.com",
                         Password = "qwerty123",
                         Role = "Guest"
                     },
                      new Users
                      {
                          Login = "user3@user.com",
                          Password = "qwerty123",
                          Role = "Admin"
                      },
                       new Users
                       {
                           Login = "user4@user.com",
                           Password = "qwerty123",
                           Role = "Human"
                       },
                        new Users
                        {
                            Login = "user5@user.com",
                            Password = "qwerty123",
                            Role = "Admin"
                        }
                    );

                context.SaveChanges();
            }

        }

    }
}
