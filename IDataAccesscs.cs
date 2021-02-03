using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEntity;
namespace OnlineDataAccess
{
    public interface IDataAccesscs
    {
        List<ProCategory> GetAllCategories();
        List<Products> GetProductsByName(string pname);
        List<Products> GetProductsByCategoryname(string cname);
        Products GetProductsById(int id);
        void PostToCart(List<CartItems> lst);
        List<CartItems> GetFromCart();
        void DeleteFromCart(int id);
        void UpdateCartById(CartItems cart);
        Login1 GetPassword(string pwd);
        Login1 GetUserName(string name);
    }

   
}
