using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sipsis.Admin.Models
{
    public class CustomerVM
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdress { get; set; }
        public int UserID { get; set; }
        public int MarketID { get; set; }
    }
}