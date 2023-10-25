using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.DAL.Repositories
{
    public class HolyLocketContext : DbContext
    {
        public HolyLocketContext(DbContextOptions<HolyLocketContext> options) : base(options) { }
        public HolyLocketContext()
        {
            int i = 0;
        }

    }
}
