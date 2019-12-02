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

        public static void InitFileExtensions(DataContext context)
        {
            #region File Extensions
            List<FileExtension> fileExt = new List<FileExtension>()
            {
                new FileExtension { FileExtensionId=Enums.FileExtensions.pdf, ExtensionName=".pdf"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.jpg, ExtensionName=".jpg"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.jpeg, ExtensionName=".jpeg"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.xml, ExtensionName=".xml"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.txt, ExtensionName=".txt"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.doc, ExtensionName=".doc"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.docx, ExtensionName=".docx"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.tiff, ExtensionName=".tiff"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.mp3, ExtensionName=".mp4"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.json, ExtensionName=".json"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.ppt, ExtensionName=".pptx"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.xls, ExtensionName=".xls"},
                new FileExtension { FileExtensionId=Enums.FileExtensions.xlsx, ExtensionName=".xlsx"},
            };
            #endregion
            context.AddRange(fileExt);
            context.SaveChanges();
        }

        public static void InitRoles(DataContext context)
        {
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
