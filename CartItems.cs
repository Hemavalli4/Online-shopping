using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMVC.Models
{
    /// <summary>
    /// Cart Items Class
    /// </summary>
    public class CartItems
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Product Image
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// Product Price
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Product Brand
        /// </summary>
        public string Brand { get; set; }
      
    }
    }
