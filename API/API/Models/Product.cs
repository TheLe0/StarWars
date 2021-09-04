using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("products", Schema = "store")]
    public class Product
    {
        [Key]
        [JsonIgnore]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Column("price")]
        [JsonPropertyName("price")]
        public double Price { get; set; }

        [Column("zipcode")]
        [JsonPropertyName("zipcode")]
        public string ZipCode { get; set; }

        [Column("seller")]
        [JsonPropertyName("seller")]
        public string Seller { get; set; }

        [Column("thumbnail_hd")]
        [JsonPropertyName("thumbnailHd")]
        public string Image { get; set; }

        [Column("date")]
        [JsonPropertyName("date")]
        public string RegisterDate { get; set; }
    }
}
