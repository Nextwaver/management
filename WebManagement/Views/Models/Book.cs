using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WebManagement.Models
{
    public class Book
    {
        public string ID { get; set; }
        public string BookNo { get; set; }
        public string BookYear { get; set; }
        public string GroupGun { get; set; }
        public string GunRegIDPrefix { get; set; }
        public string GunRegIDStart { get; set; }
        public string GunRegIDEnd { get; set; }
        public string PageTotal { get; set; }

        public ErrorMessageModel _ErrorMessageModel = new ErrorMessageModel();
    
    }
}