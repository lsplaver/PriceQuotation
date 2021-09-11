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
        public decimal? DiscountAmount { get; set; }
        /* public decimal[]? CalculateDiscountAmountAndTotalPrice()
        {
            decimal discountAmount = 0;
            decimal discountPercent = 0;
            discountPercent = ((decimal)DiscountPercent / 100);
            discountAmount = (decimal)(SubTotal * discountPercent);
            // return DiscountAmount;
        // }
        
        // public decimal? CalculateTotalPrice()
        // {
            decimal totalPrice = 0;
            totalPrice = (decimal)(SubTotal - discountAmount);
            decimal[] totals = new decimal[2] { discountAmount, totalPrice };
            return totals; // totalPrice, discountAmount;
        } */
        public decimal? CalculateDiscountAmount()
        {
            // decimal? DiscountAmount = 0;
            decimal? discountPercent = 0;
            discountPercent = (decimal?)(DiscountPercent / 100.00);
            DiscountAmount = SubTotal * discountPercent;
            return DiscountAmount;
        }
        
        public decimal? CalculateTotalPrice()
        {
            decimal? totalPrice = 0;
            totalPrice = SubTotal - DiscountAmount;
            return totalPrice;
        }
    }
}
