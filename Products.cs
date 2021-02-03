using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMVC.Models
{
    /// <summary>
    /// Products Class
    /// </summary>
    public class Products
    {
        /// <summary>
        /// Product Category Id
        /// </summary>
        public int CategoryId { get; set; }
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
        /// Product Color
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Product Brand
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; set; }
       
    }
}