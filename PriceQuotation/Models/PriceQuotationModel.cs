using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PriceQuotation.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter a subtotal amount.")]
        [Range(0.01, 999999999999999.99, ErrorMessage = "Subtotal must be greater than 0")]
        public decimal? SubTotal { get; set; }
        [Required(ErrorMessage = "Please enter a discount percent.")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100")]
        public int? DiscountPercent { get; set; }
        public decimal? discountAmount;
        public decimal? CalculateDiscountAmount()
        {
            /*decimal?*/ discountAmount = 0;
            discountAmount = SubTotal / DiscountPercent;
            return discountAmount;
        }
        
        public decimal? CalculateTotalPrice()
        {
            decimal? totalPrice = 0;
            totalPrice = SubTotal - discountAmount;
            return totalPrice;
        }
    }
}
