using System;
using System.Collections.Generic;

namespace PruebaTecnica.Core.Entities
{
    public partial class Product
    {


        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }

    }


}

