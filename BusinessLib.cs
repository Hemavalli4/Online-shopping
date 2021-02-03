using OnlineEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineDataAccess;
using OnlineExceptionLib;

namespace OnlineBusiness
{
    public class BusinessLib : IBusiness
    {
        public List<ProCategory> GetAllCategories()
        {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                var lstC = dal.GetAllCategories();
                return lstC;
            }
           catch(OnlineSoppingException ex)
            {
                throw ex;
            }
        }

        public List<Products> GetProductsByName(string pname)
        {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                var lstP = dal.GetProductsByName(pname);
                return lstP;

            }
            catch (OnlineSoppingException ex)
            {
                throw ex;
            }

        }
         public List<Products> GetProductsByCategoryname(string name)
        {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                var c = dal.GetProductsByCategoryname(name);
                return c;
            }
            catch (OnlineSoppingException ex)
            {
                throw ex;
            }
          }
         public Products GetProductsById(int id)
            {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                var p1 = dal.GetProductsById(id);
                return p1;
            }
            catch (OnlineSoppingException ex)
            {
                throw ex;
            }
         }

        public void PostToCart(List<CartItems> lst)
        {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                dal.PostToCart(lst);
            }
            catch (OnlineSoppingException ex)
            {
                throw ex;
            }
        }
        public List<CartItems> GetFromCart()
        {
            try
            {
                DataAccessLib dal = new DataAccessLib();
                var lst= dal.GetFromCart();
                return lst;
            }
            catch (OnlineSoppingException ex)
            {
                throw ex;
            }
        }

        public void DeleteFromCart(int id)
        {
            DataAccessLib dal = new DataAccessLib();
            dal.DeleteFromCart(id);
        }

        public void UpdateCartById(CartItems cart)
        {
            DataAccessLib dal = new DataAccessLib();
            dal.UpdateCartById(cart);
        }
        public Login1 GetUserName(string name)
        {
            DataAccessLib dal = new DataAccessLib();
            var username = dal.GetUserName(name);
            return username;
        }
        public Login1 GetPassword(string pwd)
        {
            DataAccessLib dal = new DataAccessLib();
            var password = dal.GetPassword(pwd);
            return password;
        }
    }
}


