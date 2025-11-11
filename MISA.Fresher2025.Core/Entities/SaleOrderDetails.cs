using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MISA.Fresher2025.Core.Entities
{
    [Table("sale_order_detail")]
    public class SaleOrderDetails
    {
        [Key]
        [Column("sale_order_detail_id")]
        public string? SaleOrderDetailId { get; set; }
        [Column("item_name")]
        public string ItemName { get; set; }
        [Column("quantity")]
        public decimal quantity { get; set; }
        [Column("unit_price")]
        public decimal UnitPrice { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("sale_order_id")]
        public string SaleOrderId { get; set; }
    }
}
