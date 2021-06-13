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
            this.TypeName = this.type.FullName;
            this.AliasName = typeNameRepo[this.TypeName];
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

    [SimpleClassDetail(Name = "SimpleConcatClass", Functionality ="Provides simple concatenation functionality.")]
    public class SimpleConcatClass
    {
        public string FirstString { get; set; }
        public string SecondString { get; set; }
        public string FullString => $"{FirstString} {SecondString}";
    }

    static class Basic
    {
        public static void ValueTypeDetailAnalysis()
        {
            WriteLine("ValueType Detail Analysis");
            WriteLine("=========================");
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

            //Study Notes
            //================================================
            //Reference
            //byte[] dataBytes = BitConverter.GetBytes(x);
            //int d = dataBytes.Length;
            //Marshal.SizeOf https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.sizeof?view=net-5.0

            //OUTPUT
            //================================================
            /*
             
            Value Type Details
            ==================

            AliasName : bool        TypeName : System.Boolean       TypeSize : 4    Min :           Max :
            AliasName : char        TypeName : System.Char          TypeSize : 1    Min :           Max : ?
            AliasName : sbyte       TypeName : System.SByte         TypeSize : 1    Min : -128      Max : 127
            AliasName : byte        TypeName : System.Byte          TypeSize : 1    Min : 0         Max : 255
            AliasName : short       TypeName : System.Int16         TypeSize : 2    Min : -32768    Max : 32767
            AliasName : ushort      TypeName : System.UInt16        TypeSize : 2    Min : 0         Max : 65535
            AliasName : int         TypeName : System.Int32         TypeSize : 4    Min : -2147483648       Max : 2147483647
            AliasName : uint        TypeName : System.UInt32        TypeSize : 4    Min : 0         Max : 4294967295
            AliasName : float       TypeName : System.Single        TypeSize : 4    Min : -3.402823E+38     Max : 3.402823E+38
            AliasName : double      TypeName : System.Double        TypeSize : 8    Min : -1.79769313486232E+308    Max : 1.79769313486232E+308
            AliasName : long        TypeName : System.Int64         TypeSize : 8    Min : -9223372036854775808      Max : 9223372036854775807
            AliasName : ulong       TypeName : System.UInt64        TypeSize : 8    Min : 0         Max : 18446744073709551615
            AliasName : decimal     TypeName : System.Decimal       TypeSize : 16   Min : -79228162514264337593543950335    Max : 79228162514264337593543950335

            NOTE : bool data type doesn't have MaxValue, MinValue fields.
            NOTE : bool type inconsistency. sizeof(bool) returns 1, but Marshal.SizeOf(default(bool)) returns 4.
            NOTE : struct and enum has no predefined value, so can't use with sizeof operator..
            NOTE : char has MaxValue and MinValue but not sure where that would be useful. MaxValue = '\uffff'. MinValue = '\0'

            */
        }

        public static void AttributesAnalysis()
        {
            WriteLine("Attributes Analysis");
            WriteLine("===================");
            WriteLine();

            SimpleConcatClass simpleConcat = new SimpleConcatClass();
            simpleConcat.FirstString = ".NET";
            simpleConcat.SecondString = "Programming";

            WriteLine($"Output from class     : {simpleConcat.FullString}");

            var attribs = simpleConcat.GetType().GetCustomAttributes(false);
            
            foreach(var attrib in attribs)
            {
                var actualAttrib = attrib as SimpleClassDetail;
                WriteLine($"Output from attribute : {actualAttrib.Name} {actualAttrib.Functionality}");
            }

            /* 
            
            Attributes Analysis
            ===================

            Output from class     : .NET Programming
            Output from attribute : SimpleConcatClass Provides simple concatenation functionality.

            */
        }
    }

    [CLSCompliant(true)]
    class Program
    {
        public static void Main(string[] args)
        {
            Basic.ValueTypeDetailAnalysis();
            WriteLine("");
            Basic.AttributesAnalysis();
            ReadLine();
        }
    }
}
