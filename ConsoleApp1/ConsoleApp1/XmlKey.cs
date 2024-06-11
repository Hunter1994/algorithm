using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class XmlKey
    {
        public Guid Id { get; set; }
        public string Xml { get; set; }

        public XmlKey()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
