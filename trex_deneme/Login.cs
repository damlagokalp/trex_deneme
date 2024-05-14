using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace trex_deneme
{
    public partial class FormLogin : Form
    {
        private string connectionString;
        private SqlConnectionParameters sqlConnectionParameters=new SqlConnectionParameters();


       ControlResizer controlResizer = new ControlResizer();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (comboboxDbase.SelectedItem != null)
            {
                //comboboxtan veritabanı seçili ise main sayfasına yönlendirir
                string selectedDatabase = comboboxDbase.SelectedItem.ToString();
                MessageBox.Show("Giriş Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlConnection connection = new SqlConnection(connectionString);
                sqlConnectionParameters.databaseName = selectedDatabase;
                string connectionParamater2 = $"Data Source={sqlConnectionParameters.serverName};Initial Catalog={sqlConnectionParameters.databaseName};Integrated Security=false;User Id={sqlConnectionParameters.userName};Password={sqlConnectionParameters.password};";

                connectionString = connectionParamater2;
                FormMain formMain = new FormMain(connectionString);
                formMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen bir veritabanı seçin!");
            }

        }
        private void btnConnection_Click(object sender, EventArgs e)
        {
            sqlConnectionParameters.serverName = txtSqlServerAddress.Text;
            sqlConnectionParameters.userName = txtUsername.Text;
            sqlConnectionParameters.password=txtPassword.Text;

           
            string connectionParamater = $"Data Source={sqlConnectionParameters.serverName};Initial Catalog=master;Integrated Security=false;User Id={sqlConnectionParameters.userName};Password={sqlConnectionParameters.password};";
            SqlConnection connection = new SqlConnection(connectionParamater);

            try
            {

                connection.Open();


                DataTable databases = connection.GetSchema("Databases");

                // comboboxa veritabanı isimleri çekilir
                foreach (DataRow database in databases.Rows)
                {
                    string databaseName = database.Field<string>("database_name");
                    // Veritabanı comboboxa ekleme
                    comboboxDbase.Items.Add(databaseName);
                }

                MessageBox.Show("Bağlantı Kuruldu! Lütfen İşlem Yapmak İstediğiniz Veritabanını Seçiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message + MessageBoxIcon.Error);
            }
            finally
            {


                connection.Close();
            }
        }


       
        bool mousedown;
       
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X - 400;
                int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);


            }
        }

        private void FormLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
        
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            ControlResizer.ReSizeControl(this, this);
        }

        //public void ReSizeControl(Control control, Control TargetControl)
        //{
        //    if (IsControlResizable(control))
        //    {
        //        int referenceWidth = control.Width;
        //        int referenceHeight = 720;
        //        float widthRatio = ((float)TargetControl.Width) / (float)referenceWidth;
        //        float heightRatio = ((float)Screen.PrimaryScreen.Bounds.Height / (float)referenceHeight);
        //        SizeF size = new SizeF();
        //        size.Width = widthRatio;
        //        size.Height = heightRatio;
        //        control.Scale(size);
        //        control.Tag = 90;
        //        ResizeFont(control, widthRatio);

        //    }
        //}
        //private void ResizeFont(Control parentControl, float ratio)
        //{
        //    foreach (Control control in parentControl.Controls)
        //    {
        //        if (control.HasChildren)
        //        {
        //            ResizeFont(control, ratio);
        //        }
        //        if (control.Font != null)
        //        {
        //            control.Font = new Font(control.Font.FontFamily, control.Font.Size * ratio, control.Font.Style);
        //        }
        //    }
        //}
        //public bool IsControlResizable(Control control)
        //{
        //    if (control.Tag == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (control.Tag.ToString() == "99")
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //  }
       // }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
          //  controlResizer.ReSizeControl(this, this);
        }
    }
}

