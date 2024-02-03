using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requests
{
    public class RequestCreate
    {
        public bool ContractingWorks { get; set; } = true;
        public string Executor { get; set; } = "";
        public bool BusinessClient { get; set; } = true;
        public string CountingMethod { get; set; } = "Automatic";
        public bool VipClient { get; set; } = false;
    }
}
