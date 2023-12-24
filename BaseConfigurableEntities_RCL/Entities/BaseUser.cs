using BaseConfigurableEntities_RCL.EntityConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseConfigurableEntities_RCL.Entities
{
    public class BaseUser
    {

        public static BaseUser CreateInstance()
        {
            var instance = new BaseUser();
            foreach (var propertyInfo in typeof(BaseUser).GetProperties())
            {
                if (propertyInfo.GetCustomAttribute(typeof(DynamicDatabaseColumnAttribute)) is DynamicDatabaseColumnAttribute attribute)
                {
                    if (attribute.IsActive)
                    {
                        propertyInfo.SetValue(instance, Activator.CreateInstance(propertyInfo.PropertyType));
                    }
                }
            }
            return instance;
        }
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Id))]
        public int Id { get; set; }
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Name))]
        public string Name { get; set; } = "";

        /// <summary>
        /// The email address of the user. It should be unique.
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Email))]
        public string Email { get; set; } = "";

        /// <summary>
        /// A securely hashed version of the user's password. Never store plain text passwords.
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Password))]
        public string Password { get; set; } = "";

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(FullName))]
        public string FullName { get; set; } = "";

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(DateOfBirth))]
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        /// <summary>
        /// A reference to the user's profile picture, which could be stored as a URL or a file path
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(ProfilePicture))]
        public string ProfilePicture { get; set; } = "";

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(RegistrationDate))]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// The date and time when the user last logged in.
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(LastLogin))]
        public DateTime LastLogin { get; set; } = DateTime.MinValue;

        /// <summary>
        /// A flag indicating whether the account is active, suspended, or deactivated.
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(AccountStatus))]
        public bool AccountStatus { get; set; } = true;

        /// <summary>
        /// The role  user (e.g., admin, regular user) saved as enum
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Role))]
        public int Role { get; set; } = 0;

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Phone))]
        public string Phone { get; set; } = "";

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Adress))]
        public string Adress { get; set; } = "";

        /// <summary>
        /// Indicates whether two-factor authentication is enabled for the user.
        /// </summary>
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(TwoFactorAuthenticationStatus))]
        public bool TwoFactorAuthenticationStatus { get; set; } = false;

        ///// <summary>
        ///// Any user-specific preferences or settings.
        ///// </summary>
        //[DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Preferences))]
        //public List<string> Preferences { get; set; }

        //[DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(SocialMediaLinks))]
        //public List<string> SocialMediaLinks { get; set; }

        /// <summary>
        /// User preferences related to privacy and data sharing.
        /// </summary>
        //[DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(PrivacySettings))]
        //public List<string> PrivacySettings { get; set; }

        //[DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Authorities))]
        //public List<string> Authorities { get; set; }


    }
}
