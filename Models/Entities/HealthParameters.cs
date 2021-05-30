using Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class BodyParameters : EntityBase
    {
        public int Height { get; set; }

        public double Weight { get; set; }

        public int Age { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
