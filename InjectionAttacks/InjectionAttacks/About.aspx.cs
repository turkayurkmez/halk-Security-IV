using System;
using System.Web.UI;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        LabelComment.Text = TextBoxComment.Text;
    }
}