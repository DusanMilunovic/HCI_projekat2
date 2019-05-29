using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    class Tag
    {
        public string Id { get; set; }
        public Color Color { get; set; }
        public string Description { get; set; }

        public Tag(string Id, Color Color, string Description)
        {
            this.Id = Id;
            this.Color = Color;
            this.Description = Description;
        }
    }
}
