using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Console;

namespace CSharpBasics
{
    public class DataTypeInfo<T>
    {
        public string AliasName;
        public string TypeName;
        public string TypeSize;
        public string MaxValue;
        public string MinValue;
        private static Dictionary<string, string> typeNameRepo =
            new Dictionary<string, string>();
        Type type;

        public DataTypeInfo(T type)
        {
            if (typeNameRepo.Count <= 0)
            {
                LoadAllTypeNames();
            }
            this.type = type.GetType();
            this.AliasName = typeNameRepo[(this.type.FullName)];
            this.TypeName = type.GetType().FullName;
            this.TypeSize = Marshal.SizeOf((T)type).ToString();
            if (!this.AliasName.Equals("bool"))
            {
                this.MinValue = Convert.ToString(this.type.GetField("MinValue").GetValue(null));
                this.MaxValue = Convert.ToString(this.type.GetField("MaxValue").GetValue(null));
            }
        }
              
        private static void LoadAllTypeNames()
        {
            typeNameRepo.Add(typeof(bool).ToString(), "bool");
            typeNameRepo.Add(typeof(byte).ToString(), "byte");
            typeNameRepo.Add(typeof(char).ToString(), "char");
            typeNameRepo.Add(typeof(decimal).ToString(), "decimal");
            typeNameRepo.Add(typeof(double).ToString(), "double");
            typeNameRepo.Add(typeof(float).ToString(), "float");
            typeNameRepo.Add(typeof(uint).ToString(), "uint");
            typeNameRepo.Add(typeof(long).ToString(), "long");
            typeNameRepo.Add(typeof(sbyte).ToString(), "sbyte");
            typeNameRepo.Add(typeof(short).ToString(), "short");
            typeNameRepo.Add(typeof(ulong).ToString(), "ulong");
            typeNameRepo.Add(typeof(ushort).ToString(), "ushort");
            typeNameRepo.Add(typeof(int).ToString(), "int");
        }
    }

    static class Basic
    {
        public static void ValueTypeDetails()
        {
            WriteLine("Value Type Details");
            WriteLine("==================");
            WriteLine();

            List<object> typelist = new List<object>();

            typelist.Add(default(bool));
            typelist.Add(default(char));
            typelist.Add(default(sbyte));
            typelist.Add(default(byte));
            typelist.Add(default(short));
            typelist.Add(default(ushort));
            typelist.Add(default(int));
            typelist.Add(default(uint));
            typelist.Add(default(float));
            typelist.Add(default(double));
            typelist.Add(default(long));
            typelist.Add(default(ulong));
            typelist.Add(default(decimal));

            typelist.ForEach(x =>
            {
                var dataTypeInfo = new DataTypeInfo<object>(x);
                WriteLine($"AliasName : {dataTypeInfo.AliasName} \tTypeName : {dataTypeInfo.TypeName}  \tTypeSize : {dataTypeInfo.TypeSize}  \tMin : {dataTypeInfo.MinValue}   \tMax : {dataTypeInfo.MaxValue}");
            }
            );

            WriteLine("\n");
            WriteLine("NOTE : bool data type doesn't have MaxValue, MinValue fields.");
            WriteLine("NOTE : bool type inconsistency. sizeof(bool) returns 1, but Marshal.SizeOf(default(bool)) returns 4.");
            WriteLine("NOTE : struct and enum has no predefined value, so can't use with sizeof operator..");
            WriteLine("NOTE : char has MaxValue and MinValue but not sure where that would be useful. MaxValue = '\\uffff'. MinValue = '\\0'");
            
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Basic.ValueTypeDetails();
            Boolean b = false;
            WriteLine(sizeof(int));
            ReadLine();
        }
    }
}
