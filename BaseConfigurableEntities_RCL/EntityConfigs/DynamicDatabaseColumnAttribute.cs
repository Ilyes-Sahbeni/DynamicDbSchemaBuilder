using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BaseConfigurableEntities_RCL.EntityConfigs
{
    /// <summary>
    /// Custom attribute to mark properties for dynamic database column creation
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DynamicDatabaseColumnAttribute : Attribute
    {
        /// <summary>
        ///  Column can be saved in Entity or not 
        /// </summary>
        public bool IsActive { get; }
        public Type ConfigType { get; }

        /// <param name="EntityPropertiesConfigs_Type">This is the static that hold the properties config</param>
        /// <param name="propertyName">The property of focus</param>
        public DynamicDatabaseColumnAttribute(Type EntityPropertiesConfigs_Type, string propertyName)
        {
            ConfigType = EntityPropertiesConfigs_Type;
            // Get the PropertyInfo of the static property by name
            PropertyInfo propertyInfo = EntityPropertiesConfigs_Type?.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo != null)
            {
                // Get the value of the static property
                // in the case of static properties, since there's no instance associated, you pass null. The null effectively means "there is no specific instance; just get the value of the static property defined on the class itself."
                object propertyConfigValue = propertyInfo?.GetValue(null);

                IsActive = (bool)propertyConfigValue;
            }
            else
            {
                Console.WriteLine($"Property {propertyName} not found.");
                IsActive = false;
            }

        }
    }
}
