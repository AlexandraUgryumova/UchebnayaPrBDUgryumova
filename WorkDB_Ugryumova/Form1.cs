using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WorkDB_Ugryumova
{
    public partial class Authorization_frm : Form
    {
        DateTime dt = new DateTime();
        
        SqlDataAdapter adptr;
        DataTable table;
        SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SecurityDB_Ugryumova;Integrated Security=True");
        public Authorization_frm()
        {
            InitializeComponent();

            TableGridView();
        }
        private void TableGridView()
        {
            connect.Open();
            adptr = new SqlDataAdapter("select * from User_tbl", connect);
            table = new DataTable();
            adptr.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Authorization_frm_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = DateTime.Today;
            string log = textBox1.Text;
            string pass = textBox2.Text;
            if(log == "" || pass == "")
            {
                MessageBox.Show("заполнены не все поля", "сообщение");
            }
            else
            {
                connect.Open();
                string prov = $"SELECT Login FROM dbo.User_tbl WHERE Login = {log}";
                adptr = new SqlDataAdapter(prov, connect);
                DataTable tables = new DataTable();
                adptr.Fill(tables);
                if (tables.Rows.Count > 0) MessageBox.Show("данный логин уже зарезервирован другим пользователем", "сообщение");
                else
                {
                    string query = $"INSERT INTO dbo.User_tbl (login,  password,  Count,  date,  active,   role) VALUES('{log}','{pass}',0,'{dt.ToString("yyyy-MM-dd")}','True','user')";
                    adptr = new SqlDataAdapter(query, connect);
                    table = new DataTable();
                    adptr.Fill(table);
                    dataGridView1.DataSource = table;
                    TableGridView();
                }
                connect.Close();
            }
        }

        private void Input_btn_Click(object sender, EventArgs e)
        {
            string log = Log_txt.Text;
            string pass = Pass_txt.Text;
            if(log == "" || pass == "")
            {
                MessageBox.Show("заполнены не все поля", "сообщение");
            }
            else
            {

            }
        }
    }
}
