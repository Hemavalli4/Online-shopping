using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineBusiness;
using OnlineEntity;


namespace OnlineWebAPI.Controllers
{
    public class OnlineController : ApiController
    {
        /// <summary>
        /// This method retrieves the products from database
        /// </summary>
        /// <param name="pname"> It is used to pass the product name</param>
        /// <returns> Products found based on pname</returns>
        [Route("api/Online/GetProductsByName/{pname}")]
        public List<Products> GetProductsByName(string pname)
        {
            BusinessLib bll = new BusinessLib();
            var P = bll.GetProductsByName(pname);
            return P;
        }
        /// <summary>
        /// this method retrieves product based on product category
        /// </summary>
        /// <param name="name"> It is used to pass the product category name</param>
        /// <returns> products found based on name</returns>
        [Route("api/Online/GetProductsByCategoryname/{name}")]
        public List<Products> GetProductsByCname(string name)
        {
            BusinessLib bll = new BusinessLib();
            var lstB = bll.GetProductsByCategoryname(name);
            return lstB;
        }
        /// <summary>
        /// this method retrieves all product category names
        /// </summary>
        /// <returns> Displays all product categories</returns>
        [Route("api/Online/GetAllCategories")]
        public List<ProCategory> GetAllCategoriesById()
        {
            BusinessLib bll = new BusinessLib();
            var c = bll.GetAllCategories();
            return c;
        }
        /// <summary>
        /// this method retrieves products based on product id
        /// </summary>
        /// <param name="id">It is used to pass product id</param>
        /// <returns>products found based on product id</returns>
        [Route("api/Online/GetProductsById/{id}")]
        public Products GetProductsById(int id)
        {
            BusinessLib bll = new BusinessLib();
            var p1 = bll.GetProductsById(id);
            return p1;
        }
        /// <summary>
        /// this method add products to cart
        /// </summary>
        /// <param name="lst">It is used to store carts in list </param>
        /// <returns> Products added to cartitems</returns>
        [Route("api/Online/AddToCart")]
        public HttpResponseMessage post([FromBody] List<CartItems> lst)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Product added to cart");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.PostToCart(lst);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// this method retrieves products from cart
        /// </summary>
        /// <returns> products retrieved from cart</returns>
        [Route("api/Online/GetFromCart")]
        public List<CartItems> GetFromCart()
        {
            BusinessLib bll = new BusinessLib();
            var lstC = bll.GetFromCart();
            return lstC;
        }
        /// <summary>
        /// this method deletes products from cart
        /// </summary>
        /// <param name="id">It is used to pass product id to delete product from cart</param>
        /// <returns> products deleted from cartitems</returns>
        [Route("api/Online/DeleteFromCart/{id}")]
        public HttpResponseMessage DeleteFromCart(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Product deleted from cart");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.DeleteFromCart(id);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return errRes;
        }
        /// <summary>
        /// this method updates products stored in database /// </summary>
        /// <param name="cart"></param>
        /// <param name="id">It is used to update cart based on product id</param>
        /// <returns>products updated  based on product id</returns>
        [Route("api/Online/UpdateCartById/{id}")]
        public HttpResponseMessage Put([FromBody] CartItems cart, int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "record updated");
            try
            {
                BusinessLib bll = new BusinessLib();
                bll.UpdateCartById(cart);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return errRes;
        }
    }
}

