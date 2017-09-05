using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Domain
{
    public class Card
    {
        [Key]
        public Int64 CardId { get; set; }
        [Required, CreditCard, Key, MaxLength(16)] public CreditCardAttribute Number { get; set; }
        // Добавить крипто
        [MaxLength(4)] public Int32 PinCode { get; set; }

        public Boolean IsBlocked { get; set; }
        public Int64 Cash { get; set; }
    }
}
