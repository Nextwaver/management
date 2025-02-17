using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebManagement.Models
{
    public class ErrorMessageModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
