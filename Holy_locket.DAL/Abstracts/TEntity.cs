using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Abstracts
{
    public abstract class TEntity
    {
        public virtual int Id { get; set; }
        public virtual bool Inactive { get; set; }
    }
}
