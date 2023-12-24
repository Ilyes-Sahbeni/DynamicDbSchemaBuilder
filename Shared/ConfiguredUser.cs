using BaseConfigurableEntities_RCL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDbSchemaBuilder.Shared
{
    public class ConfiguredUser : BaseUser
    {
        public static ConfiguredUser CreateInstance()
        {
            var instance = new ConfiguredUser();
            instance = (ConfiguredUser)BaseUser.CreateInstance();
            foreach (var propertyInfo in typeof(ConfiguredUser).GetProperties())
            {
                propertyInfo.SetValue(instance, Activator.CreateInstance(propertyInfo.PropertyType));
            }
            return instance;
        }
    }
}
