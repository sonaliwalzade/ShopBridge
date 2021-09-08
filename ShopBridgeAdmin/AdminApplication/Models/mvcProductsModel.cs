using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApplication.Models
{
    public class mvcProductsModel
    {
        public int ProductId { get; set; }

        [Required (ErrorMessage ="This is mandetory filed")]
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
    }
}