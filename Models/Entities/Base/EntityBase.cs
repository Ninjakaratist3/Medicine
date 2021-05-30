using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities.Base
{
    public class EntityBase : IEntityBase<long>
    {
        public long Id { get; set; }
    }
}
