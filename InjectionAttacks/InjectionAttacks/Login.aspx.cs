using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");

        SqlCommand sqlCommand = new SqlCommand(" SELECT * FROM Employees WHERE FirstName = @username AND LastName = @pass", sqlConnection);

        sqlCommand.Parameters.AddWithValue("@username", TextBoxUserName.Text);
        sqlCommand.Parameters.AddWithValue("@pass", TextBoxPassword.Text);


        sqlConnection.Open();
        var reader = sqlCommand.ExecuteReader();
        if (reader.Read())
        {
            Label1.Text = "Hoşgeldiniz..." + reader[2].ToString();
        }
        else
        {
            Label1.Text = "Hatalı giriş";

        }
        sqlConnection.Close();
    }
}