using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public Type(int Id, string Name, string Icon, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Icon = Icon;
            this.Description = Description;
        }
    }
}
