using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Helper
{
    internal class EnumHelper
    {
        public static partial class Helper
        {
            public static T ReadEnum<T>(string caption)
                where T : Enum
            {
                var menus = Enum.GetValues(typeof(T));
                foreach (var item in menus)
                {
                    Type uType = Enum.GetUnderlyingType(typeof(T));
                    var id = Convert.ChangeType(item, uType);

                    Console.WriteLine($"{id.ToString().PadLeft(2, ' ')}. {item}");
                }

                string income;
            l1:
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(caption);
                Console.ForegroundColor = oldColor;
                income = Console.ReadLine();

                if (!Enum.TryParse(typeof(T), income, out object value) || !Enum.IsDefined(typeof(T), value))
                {
                    goto l1;
                }
                return (T)value;
            }
        }
}
