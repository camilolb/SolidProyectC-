using System;
namespace PruebaTecnica.Core.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }

        public virtual Product Product { get; set; }

    }
}