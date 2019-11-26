using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class DataSeeder
    {
        public static void InitData(DataContext context)
        {
            #region Users
            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser(){
                    Email="test@test.ru"
                },
            };
            #endregion

            #region Roles
            List<ApplicationRole> roles = new List<ApplicationRole>()
            {
                new ApplicationRole()
                {
                    Name = Roles.Administrator.ToString(),
                    NormalizedName = Roles.Administrator.ToString().ToUpper()
                },
                new ApplicationRole()
                {
                    NormalizedName = Roles.Inspector.ToString().ToUpper(),
                    Name = Roles.Inspector.ToString()
                },
                new ApplicationRole()
                {
                    NormalizedName = Roles.Specialist.ToString().ToUpper(),
                    Name = Roles.Specialist.ToString()
                },
                new ApplicationRole()
                {
                    Name = Roles.HeadOfDepartment.ToString(),
                    NormalizedName = Roles.HeadOfDepartment.ToString().ToUpper()
                },
                new ApplicationRole()
                {
                    Name = Roles.User.ToString(),
                    NormalizedName = Roles.User.ToString().ToUpper()
                }
            };
            #endregion

            context.AddRange(roles);
            context.SaveChanges();
        }
    }
}
