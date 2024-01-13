using System.Data.SqlClient;
using WebApp7.Models;

namespace WebApp7.Service
{
    public class ProductService
    {

        private string db_source = "serverlinuxsql.database.windows.net";
        private string db_user = "NishantAzure123";
        private string db_password = "AzureGen123@";
        private string db_database = "dblinuxsql";
        

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;

            return new SqlConnection( _builder.ConnectionString );


        }

        public List<Products> getProducts()
        {
            List<Products> productsList = new List<Products>();
            string statment = "select productId, productName, price from products";
            
            SqlConnection connection = GetConnection();

            connection.Open();
            SqlCommand sqlCommand = new SqlCommand( statment, connection );

            

            using(SqlDataReader reader =  sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products products = new Products()
                    {
                           productId = reader.GetInt32(0),
                           productName = reader.GetString(1),
                           price = reader.GetInt32(2)
                };
               

                productsList.Add(products);

                };
            }

            connection.Close();
            return productsList;

        }
    }
}
