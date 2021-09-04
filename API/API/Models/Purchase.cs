using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("purchases", Schema = "store")]
    public class Purchase
    {
        [Key]
        [JsonPropertyName("purchase_id")]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("date")]
        [JsonPropertyName("date")]
        public string TransDate { get; set; }

        [Column("value")]
        [JsonPropertyName("value")]
        public string Amount { get; set; }

        [Column("client_id")]
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [Column("card_number")]
        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }
    }
}
