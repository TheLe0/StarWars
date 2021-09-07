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

        private string _cardNumber;

        [Column("card_number")]
        [JsonPropertyName("card_number")]
        public string CardNumber 
        {
            get
            {
                return this.CardNumberFormated();
            } 
            set 
            {
                _cardNumber = value;
            }
        }

        [Column("card_holder_name")]
        [JsonIgnore]
        [JsonPropertyName("card_holder_name")]
        public string CardHolderName { get; set; }

        [Column("cvv")]
        [JsonIgnore]
        [JsonPropertyName("cvv")]
        public string CardVerificationValue { get; set; }

        [Column("exp_date")]
        [JsonIgnore]
        [JsonPropertyName("exp_date")]
        public string ExpirationDate { get; set; }

        public string CardNumberFormated()
        {
            return string.Format("**** **** **** {0}", _cardNumber.Substring(_cardNumber.Length - 4));
        }
    }
}
