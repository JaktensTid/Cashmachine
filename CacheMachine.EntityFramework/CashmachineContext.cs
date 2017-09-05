using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CashMachine.Domain;

namespace CacheMachine.EntityFramework
{
    public class CashmachineContext : DbContext
    {
        public CashmachineContext() : base("Bank")
        { }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
    }
}
