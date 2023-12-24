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
        public static bool Email { get; set; } = false;
    }
}
