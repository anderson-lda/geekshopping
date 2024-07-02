using GeekShopping.CartAPI.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model
{
    [Table("cart_detail")]
    public class CartDetail: BaseEntity
    {
        [ForeignKey("CartHeaderId")]
        public long CartHeaderId { get; set; }
        [ForeignKey("ProductId")]
        public long ProductId { get; set; }
        [Column("count")]
        public int Count { get; set; }
        public CartHeader CartHeader { get; set; }
        public Product Product { get; set; }
    }
}
