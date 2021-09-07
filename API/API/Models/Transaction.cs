using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("transactions", Schema = "store")]
    public class Transaction
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("client_id")]
        [JsonPropertyName("client_id")]
        public Guid ClientId { get; set; }

        [Column("client_name")]
        [JsonPropertyName("client_name")]
        public string ClientName { get; set; }

        [Column("total_amount")]
        [JsonPropertyName("total_to_pay")]
        public Double AmountTotal { get; set; }

        [Column("credit_card")]
        [JsonPropertyName("credit_card")]
        public CreditCard CreditCard { get; set; }
    }
}
