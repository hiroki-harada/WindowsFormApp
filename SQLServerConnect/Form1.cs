using SQLServerConnect.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLServerConnect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MyDbContext context = null;

            try
            {
                context = new MyDbContext(GetConnection());

                // 中略

                context.SaveChanges();
            }
            finally
            {
                context?.Dispose();
            }



        }

        private DbConnection GetConnection() 
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString);
            // ユーザID, パスワードは、出来れば app.config に持たせたい
            //builder.UserID = "";
            //builder.Password = "";

            DbConnection connection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            connection.ConnectionString = builder.ConnectionString;
            return connection;
        }
    }
}
