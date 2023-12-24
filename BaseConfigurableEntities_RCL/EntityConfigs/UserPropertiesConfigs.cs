using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConfigurableEntities_RCL.EntityConfigs
{
    /// <summary>
    /// This class to configure wish properties will be created as columns in user table and wish are not
    /// </summary>
    public static class UserPropertiesConfigs
    {
        public static bool Id { get; set; } = true;
        public static bool Name { get; set; } = true;
        public static bool Email { get; set; } = true;
        public static bool Password { get; set; } = true;
        public static bool FullName { get; set; } = true;
        public static bool DateOfBirth { get; set; } = true;
        public static bool ProfilePicture { get; set; } = true;
        public static bool RegistrationDate { get; set; } = true;
        public static bool LastLogin { get; set; } = true;
        public static bool AccountStatus { get; set; } = true;
        public static bool Role { get; set; } = true;
        public static bool Phone { get; set; } = true;
        public static bool Adress { get; set; } = true;
        public static bool TwoFactorAuthenticationStatus { get; set; } = true;
        //public static bool Preferences { get; set; }
        //public static bool SocialMediaLinks { get; set; }
        //public static bool PrivacySettings { get; set; }
        //public static bool Authorities { get; set; }
    }
}
