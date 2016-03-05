using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Resources;

namespace SECalc.Data
{
    public class Localization
    {
        static ResourceSet resx;

        internal static string GetLocalizationForKey(string key)
        {
            string str = resx.GetString(key);

            return str != null ? str : String.Format("<{0}>", key);
        }

        static public void LoadFromFile(string filepath)
        {
        
            ResXResourceReader reader = new ResXResourceReader(filepath);
            resx = new ResourceSet(reader);
            
        }
    }
}
