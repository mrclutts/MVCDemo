using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDemo.Models
{
    public class DemoClass
    {
        public DemoClass()
        {
            this.CustomFields = new HashSet<CustomField>();
            this.CustomValues = new HashSet<CustomValue>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset Date { get; set; }

        public bool IsTrue { get; set; }

        public virtual ICollection<CustomField> CustomFields { get; set; }

        public virtual ICollection<CustomValue> CustomValues { get; set; }

    }
}
