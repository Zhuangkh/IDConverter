using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System;

namespace IDConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("GUID is null!");
                Console.ReadKey();
            }
            else
            {
                string id = args[0];
                int count = id.Length;
                switch (count)
                {
                    case 22:
                        Console.WriteLine("IFC GUID: " + id);
                        Console.WriteLine("Back to .NET GUID: " + IfcGuidConverter.FromIfcGuid(id).ToString());
                        break;
                    case 36:
                        Console.WriteLine(".NET GUID: " + id.ToString());
                        Console.WriteLine("IFC GUID: " + IfcGuidConverter.ToIfcGuid(new Guid(id)));
                        break;
                    case 45:
                        Console.WriteLine("Revit UniqueId: " + id);
                        Guid guid = RevitIDConverter.ToGuid(id);
                        Console.WriteLine(".NET GUID: " + guid.ToString());
                        Console.WriteLine("IFC GUID: " + IfcGuidConverter.ToIfcGuid(guid));
                        break;
                    default:
                        Console.WriteLine("GUID Length Error!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
