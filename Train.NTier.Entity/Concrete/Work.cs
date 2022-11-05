using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.Entity.Interface;

namespace Train.NTier.Entity.Concrete
{
    public class Work: IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
