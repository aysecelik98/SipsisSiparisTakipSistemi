using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sipsis.Admin.Models
{
    public class MarketVM
    {
        public int ID { get; set; }
        public string MarketName { get; set; }
        public int Comission { get; set; }
        public int UserID { get; set; }

    }
}