using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using OnlineEntity;
using OnlineExceptionLib;
using System.Runtime.Serialization;

namespace OnlineDataAccess
{
    public class DataAccessLib : IDataAccesscs
    {
        SqlConnection con;
        SqlCommand cmd;
        public DataAccessLib()
        {
            //Configure Connection
            con = new SqlConnection();
            //Read the connection string
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = HCLDB;Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        }
        /// <summary>
        /// This method retrieve product categories record from database 
        /// </summary>
        /// <returns> List of product categories </returns>
        public List<ProCategory> GetAllCategories()
        {
            List<ProCategory> lstC = new List<ProCategory>();
            try
            {
                //To Do Select All
                //Configure command for select all
                cmd = new SqlCommand();
                cmd.CommandText = "select cname from procategory";
                //Attach the connection with the command
                cmd.Connection = con;
                //open connection
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    ProCategory c = new ProCategory
                    {
                        //CategoryId = (int)sdr[0],
                        CategoryName = sdr[0].ToString()
                    };
                    lstC.Add(c);
                }
                //connection close
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
            return lstC;
        }
        /// <summary>
        /// Tis method retrieve Product records from database
        /// </summary>
        /// <param name="pname">It is used to pass product name whose record is to be retrieved</param>
        /// <returns>Product record found based on pname passed</returns>
        public List<Products> GetProductsByName(string pname)
        {
            List<Products> lstP = new List<Products>();
            try
            {
                //To Do Select All
                //Configure command for select all
                cmd = new SqlCommand();
                cmd.CommandText = "select * from product where pname like @pn";
                //pass value to parameter
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pn", "%" + pname + "%");
                //Attach the connection with the command
                cmd.Connection = con;
                //connection open
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Products p = new Products
                    {
                        CategoryId = (int)sdr[0],
                        ProductId = (int)sdr[1],
                        ProductName = sdr[2].ToString(),
                        Price = (int)sdr[3],
                        Picture = sdr[4].ToString(),
                        Color = sdr[5].ToString(),
                        Brand = sdr[6].ToString(),
                        Description = sdr[7].ToString(),
                    };
                    lstP.Add(p);
                }
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection Close
                con.Close();
            }
            return lstP;

        }

        /// <summary>
        /// This method retrieves product record from databse on product category name
        /// </summary>
        /// <param name="name">It is used to pass the Product category name</param>
        /// <returns>Product record found based on category name passed</returns>
    public List<Products> GetProductsByCategoryname(string name)
        {
            List<Products> lstB = new List<Products>();
            try
            {
                //To Do Select All
                //Configure command for select all
                cmd = new SqlCommand();
                cmd.CommandText = "select procategory.cid,Product.pid,product.pname,product.price,product.picture,product.color,product.brand,product.description " +
                                   "  from procategory join product on  procategory.cid=product.cid and procategory.cname like @cn";
                cmd.Parameters.Clear();
                //supply values to the parameters of the command
                cmd.Parameters.AddWithValue("@cn", "%" + name + "%");
                //Attach the connection with the command
                cmd.Connection = con;
                //Connection Open
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Products p = new Products
                    {
                        CategoryId = (int)sdr[0],
                        ProductId = (int)sdr[1],
                        ProductName = sdr[2].ToString(),
                        Price = (int)sdr[3],
                        Picture = sdr[4].ToString(),
                        Color = sdr[5].ToString(),
                        Brand = sdr[6].ToString(),
                        Description = sdr[7].ToString(),
                    };
                    lstB.Add(p);
                }
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection Close
                con.Close();
            }
            return lstB;
    }
        /// <summary>
        /// This method retrieves product record from database on product id
        /// </summary>
        /// <param name="id"> It is used to pass the product id </param>
        /// <returns> Product record found based on product id</returns>
    public Products GetProductsById(int id)
        {
            Products p1 = null;
            try
            {
                //Configure Command 
                cmd = new SqlCommand();
                cmd.CommandText = "select pid,pname,price,picture,brand from product where pid=@pid";
                cmd.Parameters.Clear();
                //supply values to the parameters of the command
                cmd.Parameters.AddWithValue("@pid", id);
                //Specify the type of Command
                cmd.CommandType = System.Data.CommandType.Text;
                // Attach connection  with command
                cmd.Connection = con;
                //Connection Open
                con.Open();
                //Execute the Command
                SqlDataReader sdr = cmd.ExecuteReader();
                    if(sdr.Read())
                   {
                    p1 = new Products();
                    p1.ProductId = (int)sdr[0];
                    p1.ProductName = sdr[1].ToString();
                    p1.Price = (int)sdr[2];
                    p1.Picture = sdr[3].ToString();
                    p1.Brand = sdr[4].ToString();
                   }
                else
                  {
                      throw new Exception("product does  exist");
                  }
            }
            catch(SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection Close
                con.Close();
            }
          return p1;
    }
        /// <summary>
        /// This method add products into the cart item
        /// </summary>
        /// <param name="lst">It is used to store  cart items in list</param>
        public void PostToCart(List<CartItems> lst)
        {
            try
            {
                //Connection Open
                con.Open();
                foreach (var p in lst)
                {
                    //Configure the Command
                    cmd = new SqlCommand();
                    cmd.CommandText = "insert into cart values(@pid,@pname,@pic,@price,@brand)";
                    //Attach connection to the command
                    cmd.Connection = con;
                    //specify the type of command
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    //supply values to the parameters of the command
                    cmd.Parameters.AddWithValue("@pid", p.ProductId);
                    cmd.Parameters.AddWithValue("@pname",p.ProductName);
                    cmd.Parameters.AddWithValue("@pic", p.Picture);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@brand", p.Brand);
                    int item= cmd.ExecuteNonQuery();
                    if(item==0)
                    {
                        throw new Exception("product not added");
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
    }
        /// <summary>
        /// This method retrieve the products stored in cart 
        /// </summary>
        /// <returns>Products stored in cart </returns>
        public List<CartItems> GetFromCart()
        {
            try
            {
                List<CartItems> lstC = new List<CartItems>();
                //Configure Command
                cmd = new SqlCommand();
                cmd.CommandText = "select pid,pname,picture,price,brand from cart";
                //specify the type of command
                cmd.CommandType = CommandType.Text;
                //Attach the connection
                cmd.Connection = con;
                //Connection open
                con.Open();
                //Execute the command
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CartItems cart = new CartItems
                    {
                        ProductId = (int)sdr[0],
                        ProductName = sdr[1].ToString(),
                        Picture = sdr[2].ToString(),
                        Price = (int)sdr[3],
                        Brand = sdr[4].ToString(),
                    };
                    lstC.Add(cart);
                }
                sdr.Close();
                return lstC;
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
        }
        /// <summary>
        /// This method delete the products from cart
        /// </summary>
        /// <param name="id"> It is used to pass the product id whose record is to be deleted</param>
        public void DeleteFromCart(int id)
        {
            try
            {
                //Configure command
                cmd = new SqlCommand();
                cmd.CommandText = "delete from cart where pid=@pid";
                //Specify the type of command
                cmd.CommandType = System.Data.CommandType.Text;
                //Attach the connection
                cmd.Connection=con;
                //Connection open
                con.Open();
                cmd.Parameters.Clear();
                //supply values to the parametres ofcommand
                cmd.Parameters.AddWithValue("@pid", id);
                int item = cmd.ExecuteNonQuery();
                if(item==0)
                {
                    throw new Exception("Item not exists in the cart");
                }
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
        }
        public void UpdateCartById(CartItems cart)
        {
            try
            {
                //Configure command
                cmd = new SqlCommand();
                cmd.CommandText =" Update cart set pname=@pname,picture=@pic,price=@price,brand=@brand from cart where pid=@pid";
                //Specify the type of command
                cmd.CommandType = System.Data.CommandType.Text;
                //Attach the connection
                cmd.Connection = con;
                //Connection open
                con.Open();
                cmd.Parameters.Clear();
                //supply values to the parameters of the command
                cmd.Parameters.AddWithValue("@pid", cart.ProductId);
                cmd.Parameters.AddWithValue("@pname", cart.ProductName);
                cmd.Parameters.AddWithValue("@pic",cart.Picture );
                cmd.Parameters.AddWithValue("@price",cart.Price);
                cmd.Parameters.AddWithValue("@brand", cart.Brand);
                int recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Item not exists in the cart");
                }
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
        }
        public Login1 GetPassword(string pwd)
        {
            Login1 lr = new Login1();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "select password from Login1 where password=@pw";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@pw", pwd);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    lr.Password = sdr[0].ToString();
                }
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
            return lr;
        }
        public Login1 GetUserName(string name)
        {
            Login1 lr = new Login1();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "select username from Login1 where username=@un";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@un", name);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    lr.UserName = sdr[0].ToString();
                }
                sdr.Close();
            }
            catch (SqlException ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new OnlineSoppingException(ex.Message);
            }
            finally
            {
                //Connection close
                con.Close();
            }
            return lr;
        }
       
    }
}




