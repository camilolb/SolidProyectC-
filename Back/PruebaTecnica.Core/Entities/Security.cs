using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaTecnica.Core.Entities
{
    public class Security
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string Token { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
    }
}
