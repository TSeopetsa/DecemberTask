using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApp.Pages.Clients
{
    public class Create : PageModel
    {
        public ClientInfo ClientData = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            ClientData.name = Request.Form["name"];
            ClientData.email = Request.Form["email"];
            ClientData.phone = Request.Form["phone"];
            ClientData.address = Request.Form["address"];

            if (ClientData.name.Length == 0 || ClientData.email.Length==0 || ClientData.phone.Length == 0 || ClientData.address.Length == 0)
            {
                errorMessage = "Every field requires input";
                return;
            }

            //save client into database
            try
            {
                String connectionString = "Data Source=(localdb)\\local;Initial Catalog=Web1;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO clients " +
                        "(name, email, phone, address) VALUES " +
                        "(@name, @email, @phone, @address);";

                    using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@name" , ClientData.name);
                        command.Parameters.AddWithValue("@email" , ClientData.email);
                        command.Parameters.AddWithValue("@phone", ClientData.phone);
                        command.Parameters.AddWithValue("@address" , ClientData.address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage= ex.Message;
                return;

            }

            ClientData.name = "";
            ClientData.email = "";
            ClientData.phone = "";
            ClientData.address = "";
            successMessage = "New Client Created";

            Response.Redirect("/Shared/logged");
        }
    }
}
