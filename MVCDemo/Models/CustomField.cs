using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class CustomField
    {

        public int Id { get; set; }

        public string FieldName { get; set; }

        public int DemoClassId { get; set; }

        public bool IsCheckBox { get; set; }

        public bool IsTextBox { get; set; }

        public bool IsInt { get; set; }
        public virtual DemoClass DemoClass { get; set; }

        

    }
}
