using System;
using static System.Console;

namespace CSharpBasics
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleClassDetail : System.Attribute
    {
        public string Name { get; set; }
        public string Functionality { get; set; }

        public static string  GetTypeDetails(Type type)
        {
            string output = string.Empty;
            var attributes = type.GetCustomAttributes(false);
            foreach(var attrib in attributes)
            {
                if (attrib is SimpleClassDetail)
                {
                    var actualAttribOne = attrib as SimpleClassDetail;
                    output += ($"\nOutput from static attribute method(codevariation_one) : {actualAttribOne.Name} | {actualAttribOne.Functionality}");
                }

                var actualAttribTwo = attrib as SimpleClassDetail;
                if(actualAttribTwo != null)
                {
                    output +=  ($"\nOutput from static attribute method(codevariation_two) : {actualAttribTwo.Name} | {actualAttribTwo.Functionality}");
                }

            }
            return output;
        }
    }
}
