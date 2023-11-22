using Catalog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace X_0
{
    /// <summary>
    /// Interaction logic for CreateANewAccount.xaml
    /// </summary>
    public partial class CreateANewAccount : Window
    {
        public CreateANewAccount()
        {
            InitializeComponent();
        }
        private void Enter_click(object sender, EventArgs e)
        {
            using (SqlConnection con = Connection.Con)
            {
                SqlCommand cmd = new SqlCommand("InsertInPlayers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", n.Text);
                SqlParameter paramParola = new SqlParameter("@parola", p.Text);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramParola);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
