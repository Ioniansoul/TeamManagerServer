using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamManagerServer.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public decimal Contribution { get; set; }
    }
}