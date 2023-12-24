using BaseConfigurableEntities_RCL.EntityConfigs


namespace BaseConfigurableEntities_RCL
{
    public class BaseUser
    {
        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Id))]
        public int Id { get; set; }

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Name))]
        public string Name { get; set; }

        [DynamicDatabaseColumn(typeof(UserPropertiesConfigs), nameof(Email))]
        public string Email { get; set; }

        // Step 6: Include other common properties
    }
}
