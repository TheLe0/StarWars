using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("users", Schema = "store")]
    public class User
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("username")]
        [Column("username")]
        public string Username { get; set; }

        [JsonIgnore]
        [Column("password")]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        [Column("role")]
        public RoleType Role { get; set; }
    }
}
