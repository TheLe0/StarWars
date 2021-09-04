using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("credit_cards", Schema = "store")]
    public class CreditCard
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("card_number")]
        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }

        [Column("card_holder_name")]
        [JsonPropertyName("card_holder_name")]
        public string CardHolderName { get; set; }

        [Column("cvv")]
        [JsonPropertyName("cvv")]
        public string CardVerificationValue { get; set; }

        [Column("exp_date")]
        [JsonPropertyName("exp_date")]
        public string ExpirationDate { get; set; }
    }
}
