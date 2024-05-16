﻿using System;
using System.Collections.Generic;

namespace VerbHppt.Models
{
    public partial class CustomerDTO
    {
        
        public string CustomerId { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }

    }
}
