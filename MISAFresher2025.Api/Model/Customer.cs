using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Fresher2025.Api.Model
{
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public string? CustomerId { get; set; }
        [Column("customer_code")]
        public string CustomerCode { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("customer_addr")]
        public string CustomerAddr { get; set; }
    }
}
