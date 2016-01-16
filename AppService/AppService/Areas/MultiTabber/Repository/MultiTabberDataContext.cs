using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppService.Areas.MultiTabber.Repository
{
    public class MultiTabberDataContext:DbContext
    {
        public MultiTabberDataContext():base("MultiTabber")
        {

        }

        public DbSet<UserTable> Tabber { get; set; }
        public DbSet<ErrTable> ErrTabber { get; set; }
    }
}