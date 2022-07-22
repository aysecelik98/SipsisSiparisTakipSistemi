using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sipsis.Admin.Models
{
    public class CargoVM
    {
        public int ID { get; set; }
        public string CargoName { get; set; }
        public string CargoImageURL { get; set; }
        public int UserID { get; set; }

    }
}