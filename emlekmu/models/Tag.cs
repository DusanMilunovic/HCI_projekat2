using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    public class Tag
    {
        public string Id { get; set; }
        public Color Color { get; set; }
        public string Description { get; set; }

        public Tag()
        {

        }

        public Tag(string Id, Color Color, string Description)
        {
            this.Id = Id;
            this.Color = Color;
            this.Description = Description;
        }

        public Tag()
        {
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (this.Id == ((Tag)obj).Id)
            {
                return true;
            }
            return false;

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
