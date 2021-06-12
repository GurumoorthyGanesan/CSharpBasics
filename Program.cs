using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpBasics
{

    static class Basic
    {
        private static Dictionary<string, string> types =
            new Dictionary<string, string>();
        
        private static void LoadTypeDetails()
        {
            types.Add(typeof(bool).ToString(), "bool");
            types.Add(typeof(byte).ToString(), "byte");
            types.Add(typeof(char).ToString(), "char");
            types.Add(typeof(decimal).ToString(), "decimal");
            types.Add(typeof(double).ToString(), "double");
            types.Add(typeof(float).ToString(), "float");
            types.Add(typeof(uint).ToString(), "uint");
            types.Add(typeof(long).ToString(), "long");
            types.Add(typeof(sbyte).ToString(), "sbyte");
            types.Add(typeof(short).ToString(), "short");
            types.Add(typeof(ulong).ToString(), "ulong");
            types.Add(typeof(ushort).ToString(), "ushort");
            types.Add(typeof(int).ToString(), "int");
        }

        public static void SizeOfProgram()
        {
            bool boolVariable = default(bool);
            byte byteVariable = default(byte);
            char charVariable = default(char);
            decimal decimalVariable = default(decimal);
            double doubleVariable = default(double);
            float floatVariable = default(float);
            uint uintVariable = default(uint);
            long longVariable = default(long);
            sbyte sbyteVariable = default(sbyte);
            short shortVariable = default(short);
            ulong ulongVariable = default(ulong);
            ushort ushortVariable = default(ushort);
            int intVariable = default(int);

            List<object> typelist= new List<object>();

            typelist.Add(intVariable);
            typelist.Add(byteVariable);
            typelist.Add(charVariable);
            typelist.Add(decimalVariable);
            typelist.Add(doubleVariable);
            typelist.Add(floatVariable);
            typelist.Add(uintVariable);
            typelist.Add(longVariable);
            typelist.Add(sbyteVariable);
            typelist.Add(shortVariable);
            typelist.Add(ulongVariable);
            typelist.Add(ushortVariable);

            LoadTypeDetails();

            Func<object,string> getTypeName = x => types[x.GetType().ToString()];
            typelist.ForEach(x => WriteLine($"{getTypeName(x)}\t\t(MIN : {x.GetType().GetField("MinValue").GetValue(null)}) (MAX : {x.GetType().GetField("MaxValue").GetValue(null)})"));

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Basic.SizeOfProgram();
            ReadLine();
        }
    }
}
