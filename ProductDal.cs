using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo1
    {
        public class ProductDal
        {
        //Listelerle Veri Okuma
        SqlConnection _connection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=ETrade1; integrated security=false;");

        //public List<Product> GetAll()
        //{
        //    ConnectionControl();
        //    SqlCommand command = new SqlCommand("Select * from Product", _connection);
        //    SqlDataReader reader = command.ExecuteReader();

        //    List<Product> list = new List<Product>();

        //    while (reader.Read())
        //    {
        //        Product product1 = new Product()
        //        {


        //            Id = Convert.ToInt32(reader["Id"]),
        //            Name = reader["Name"].ToString(),
        //            UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
        //            StockAmount = Convert.ToInt32(reader["StockAmount"]),
        //        };
        //        Product.Add(product1);
        //    }

        //    reader.Close();
        //    _connection.Close();

        //}

        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();

            }
        }

        //Datatable ile veri okuma

        
        public DataTable GetAll()
        {

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();

            }
            SqlCommand command = new SqlCommand("Select * from Product", _connection);
            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            _connection.Close();
            return dataTable;
        }
        
        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
          "Insert into Product values(@name,@unitPrice,@stockAmount)", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.ExecuteNonQuery();

            _connection.Close();

        }

      

        public void Update(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
             "Update Product set Name=@name,UnıtPrice=@unitPrice,StockAmount=@stockAmount where Id=@id", _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@stockAmount", product.StockAmount);
            command.Parameters.AddWithValue("@id", product.Id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand(
             "Delete from Product where Id=@id", _connection);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();

            _connection.Close();

        }
    }

    }



