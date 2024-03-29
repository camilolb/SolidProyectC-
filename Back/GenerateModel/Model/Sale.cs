﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GenerateModel.Model
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Total { get; set; }

        public virtual Product Product { get; set; }
    }
}
