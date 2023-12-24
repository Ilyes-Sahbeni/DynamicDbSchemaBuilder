using BaseConfigurableEntities_RCL.Entities;
using BaseConfigurableEntities_RCL.EntityConfigs;
using DynamicDbSchemaBuilder.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace DynamicDbSchemaBuilder.Server
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ConfiguredUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InitiatingUserPropertiesConfigs();



            #region ignore creating columns in entity configured to be non active
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var propertiesToIgnore = entityType.GetProperties()
                    .Where(property =>
                        property.PropertyInfo?.GetCustomAttribute(typeof(DynamicDatabaseColumnAttribute)) is DynamicDatabaseColumnAttribute attribute &&
                        !attribute.IsActive)
                    .ToList();

                if (propertiesToIgnore.Any())
                {
                    foreach (var property in propertiesToIgnore)
                    {
                        modelBuilder.Entity(entityType.ClrType).Ignore(property.Name);
                    }
                }
            }
            #endregion

        }
        public void InitiatingUserPropertiesConfigs()
        {
            UserPropertiesConfigs.Id = true;
            UserPropertiesConfigs.Name = true;
            UserPropertiesConfigs.Email = false;
            UserPropertiesConfigs.Password = true;
            UserPropertiesConfigs.FullName = false;
            UserPropertiesConfigs.DateOfBirth = false;
            UserPropertiesConfigs.ProfilePicture = false;
            UserPropertiesConfigs.RegistrationDate = false;
            UserPropertiesConfigs.LastLogin = false;
            UserPropertiesConfigs.AccountStatus = false;
            UserPropertiesConfigs.Role = true;
            UserPropertiesConfigs.Phone = false;
            UserPropertiesConfigs.Adress = false;
            UserPropertiesConfigs.TwoFactorAuthenticationStatus = false;
        }
    }
}
