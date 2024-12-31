using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace CrudCSharpSql.Pages.Colors
{
    public class Index : PageModel
    {
        public List<ColorInfo> ColorsList { get; set; } = [];
        public void OnGet()
        {
            try
            {
                string connectionString = @"Server=localhost\SQLEXPRESS;Database=crmdb;Trusted_Connection=True;TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM colors";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ColorInfo color = new ColorInfo();
                                color.Id = reader.GetInt32(0);
                                color.Name = reader.GetString(1);
                                color.Price = reader.GetDecimal(2);
                                color.IsInStock = reader.GetBoolean(3);
                                ColorsList.Add(color);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in fetching data from database" + ex.Message);
            }
        }
    }

    public class ColorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public decimal  Price { get; set; } = 0.0m;

        public bool IsInStock { get; set; } = false;
    }
}