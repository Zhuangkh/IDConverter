using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace IDConverter
{
    public class RevitIDConverter
    {
        public static Guid ToGuid(string uniqueId)
        {
            if (uniqueId.Length != 45)
            {
                throw new Exception("the given string isn't revit unique id");
            }
            int elementId = int.Parse(uniqueId.Substring(37), NumberStyles.AllowHexSpecifier);
            int tempId = int.Parse(uniqueId.Substring(28, 8), NumberStyles.AllowHexSpecifier);
            int xor = tempId ^ elementId;
            return new Guid(uniqueId.Substring(0, 28) + xor.ToString("x8"));
        }
    }
}
