using System;
using System.Resources;

namespace Yoopala.Test.Apply.WebApp.Resources
{
    public static class LocalizationExtension
    {
        public static string GetDisplayName(this Enum value)
        {
            var rm = new ResourceManager(typeof(EnumResources));

            string resourceDisplayName = rm.GetString($"{value.GetType().Name}_{value.ToString()}");

            return resourceDisplayName ?? string.Format("[[{0}]]", value);
        }
    }
}
