﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrdersRegisterEntity
    {
        public int Id { get; set; }
        public bool ContractingWorks { get; set; }
        public string Executor {  get; set; }
        public bool BusinessClient { get; set; }
        public string CountingMethod { get; set; }
        public bool VipClient { get; set; }
    }
}
