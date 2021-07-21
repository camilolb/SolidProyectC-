using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Core.Entities
{
    public partial class Departament : BaseEntity
    {
        public string Number { get; set; }
        public int OwerId { get; set; }
        public int? BuildId { get; set; }

        public virtual Build Build { get; set; }
    }
}
