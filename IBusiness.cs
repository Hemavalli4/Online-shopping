using OnlineDataAccess;
using OnlineEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBusiness
{
   public interface IBusiness
    {
        List<ProCategory> GetAllCategories();
        List<Products> GetProductsByName(string pname);
        List<Products> GetProductsByCategoryname(string name);
        Products GetProductsById(int id);
        void PostToCart(List<CartItems> lst);
        List<CartItems> GetFromCart();
        void DeleteFromCart(int id);
        void UpdateCartById(CartItems cart);
        Login1 GetPassword(string pwd);
        Login1 GetUserName(string name);

    }
}
