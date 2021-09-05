using API.Utils;
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

        [JsonPropertyName("password")]
        [Column("password")]
        public string Password { get; set; }

        [JsonIgnore]
        [Column("role")]
        public RoleType Role { get; set; }

        public string GenerateToken()
        {
            var _token = new Token();
            this.Password = string.Empty;
            return _token.GenerateToken(this);
        }
    }
}
