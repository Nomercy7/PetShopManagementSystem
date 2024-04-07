using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class BuyItem
    {
        [Required(ErrorMessage = "This field is required")]
        public int BuyId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int? ProductId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Price { get; set; }
    }
}