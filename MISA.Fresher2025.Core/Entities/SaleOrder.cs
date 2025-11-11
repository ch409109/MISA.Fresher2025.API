using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Fresher2025.Core.Entities
{
    [Table("sale_order")]
    public class SaleOrder
    {
        [Key]
        [Column("sale_order_id")]
        public string? SaleOrderId { get; set; }
        [Column("sale_order_no")]
        public string SaleOrderNo { get; set; }
        [Column("sale_order_date")]
        public DateTime SaleOrderDate { get; set; }
        [Column("total_amount")]
        public decimal TotalAmount { get; set; }
        [Column("customer_id")]
        public string CustomerId { get; set; }
        //public List<SaleOrderDetails> SaleOrderDetails { get; set; }
    }
}
