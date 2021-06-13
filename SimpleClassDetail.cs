using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SimpleClassDetail : System.Attribute
    {
        public string Name { get; set; }
        public string Functionality { get; set; }
    }
}
