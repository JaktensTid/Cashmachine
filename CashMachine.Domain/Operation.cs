using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Domain
{
    public class Operation
    {
        [Key] public Int64 OperationId;
        public DateTime Time;
        [MaxLength(255)] public String Message;
        public Card Card { get; set; }
        [ForeignKey("Card")]
        public Int64 CardId { get; set; }
        [ForeignKey("Card")]
        public CreditCardAttribute Number { get; set; }
    }
}
