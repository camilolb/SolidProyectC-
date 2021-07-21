using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
    }
}
