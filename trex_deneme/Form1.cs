﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using trex_deneme.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using ListView = System.Windows.Forms.ListView;
using Size = System.Drawing.Size;

namespace trex_deneme
{

    public partial class FormMain : Form
    {
        List<ListViewItem> overallItems = new List<ListViewItem>();
        private Dictionary<ListViewItem, bool> _checkedItems = new Dictionary<ListViewItem, bool>();
        private List<string> _overviewItems = new List<string>();
        private Dictionary<string, int> _listViewManager = new Dictionary<string, int>();
        int totalSelectedRowCount = 0;
        private bool IsFullScreen = false;
        private static string connectionString=string.Empty;
        SqlConnection baglanti = new SqlConnection(connectionString);

         ControlResizer controlResizer = new ControlResizer();


        public FormMain(string connection)
        {
            InitializeComponent();
            connectionString = connection;
           // btnSystemResource.Click += btnSystemResource_Clicked;

        }
        //@"Data Source=(local); Initial Catalog=TREXOPTIMIZER; Integrated Security=false;user id=sa;password=123"
        //  SqlConnection baglanti = new SqlConnection(connectionString);

         SqlConnectionParameters sqlConnectionParameters = new SqlConnectionParameters();

       

        private void Form1_Load(object sender, EventArgs e)
        {
             baglanti = new SqlConnection(connectionString);
            _listViewManager[listViewDataLoss.Name] = 0;
            _listViewManager[listViewPerformance.Name] = 0;
            _listViewManager[listViewSystemResource.Name] = 0;

            UpdateTabCount(btnAllIssues);
            // UpdateSelectedRowCount(btnTaskList);
            // UpdateFixitCount(btnFixit);

            ControlResizer.ReSizeControl(this, this);


            //tabpageler gizlendi
            tabControls.Appearance = TabAppearance.FlatButtons;
            tabControls.ItemSize = new Size(0, 1);
            tabControls.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tabControls.TabPages)
            {
                tab.Text = "";

            }

               // Bağlantıyı aç

                // Seçilen veritabanındaki tüm tabloları almak için sorgu oluştur
                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", baglanti);

                // Tabloları al
                List<string> tables = new List<string>();
                using (SqlDataReader oku = command.ExecuteReader())
                {
                    while (oku.Read())
                    {

                    tables.Add(oku["TABLE_NAME"].ToString());

                    
                    }
                }

            // Her bir tabloyu döngüyle işle
            foreach (string table in tables)
            {
                // Tabloya ait verileri çekmek için sorgu oluştur
                SqlCommand tableCommand = new SqlCommand($"SELECT * FROM {table}", baglanti);
                SqlDataReader oku = tableCommand.ExecuteReader();

                // ListView'e verileri ekle
                while (oku.Read())
                {
                    ListViewItem item = new ListViewItem(oku["id"].ToString());
                    item.SubItems.Add(oku["type"].ToString());
                    item.SubItems.Add(oku["parentObject"].ToString());
                    item.SubItems.Add(oku["objectType"].ToString());
                    item.SubItems.Add(oku["object"].ToString());
                    item.SubItems.Add(oku["ratio"].ToString());
                    item.SubItems.Add(oku["description"].ToString());
                    item.SubItems.Add(oku["isFixible"].ToString());

                    listViewDataLoss.Items.Add(item);
                  
                }

                oku.Close(); // Okuyucuyu kapat
            }
            baglanti.Close();

            ////DATALOSS tablosu için veritabanındaki verileri okur

            //baglanti.Open();
            //SqlCommand komut = new SqlCommand("select * from DATALOSS", baglanti);
            //SqlDataReader oku = komut.ExecuteReader();
            //while (oku.Read())
            //{

            //    ListViewItem item = new ListViewItem(oku["id"].ToString());
            //    item.SubItems.Add(oku["type"].ToString());
            //    item.SubItems.Add(oku["parentObject"].ToString());
            //    item.SubItems.Add(oku["objectType"].ToString());
            //    item.SubItems.Add(oku["object"].ToString());
            //    item.SubItems.Add(oku["ratio"].ToString());
            //    item.SubItems.Add(oku["description"].ToString());
            //    item.SubItems.Add(oku["isFixible"].ToString());

            //    listViewDataLoss.Items.Add(item);
            //}
            //baglanti.Close();


            foreach (ListViewItem item in listViewDataLoss.Items)
            {
                ColorManager.AssignColor(item);
            }
            CountListView(listViewDataLoss, btnDataLoss);



            //Renklendirme
            //foreach (ListViewItem item in listViewDataLoss.Items)
            //{

            //    if (item.SubItems[1].Text == "Fragmentation")
            //    {
            //        item.BackColor = Color.FromArgb(255, 252, 131);
            //    }

            //    if (item.SubItems[1].Text == "Unnecessary Object")
            //    {
            //        item.BackColor = Color.FromArgb(143, 184, 237);
            //    }

            //    if (item.SubItems[1].Text == "Wrong Configuration")
            //    {
            //        item.BackColor = Color.FromArgb(224, 30, 55);
            //    }
            //    if (item.SubItems[1].Text == "Low Disk Space")
            //    {
            //        item.BackColor = Color.FromArgb(128, 237, 153);
            //    }
            //    if (item.SubItems[1].Text == "Corruption")
            //    {
            //        item.BackColor = Color.FromArgb(194, 187, 240);
            //    }
            //    CountListView(listViewDataLoss, btnDataLoss);

            //}





            //string sorgu = @"
            //                         SELECT * 
            //                         FROM PERFORMANCE 
            //                        WHERE (SELECT avg_fragmentation_in_percent 
            //            FROM sys.dm_db_index_physical_stats(DB_ID(), OBJECT_ID(N'TabloAdi'), NULL, NULL, NULL)) > 50";

            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(sorgu,con);
            //    con.Open();
            //    SqlDataReader oku2 = command.ExecuteReader();
            //    while (oku2.Read())
            //    {
            //        ListViewItem item2 = new ListViewItem(oku2["id"].ToString());
            //        item2.SubItems.Add(oku2["type"].ToString());
            //        item2.SubItems.Add(oku2["parentObject"].ToString());
            //        item2.SubItems.Add(oku2["objectType"].ToString());
            //        item2.SubItems.Add(oku2["object"].ToString());
            //        item2.SubItems.Add(oku2["ratio"].ToString());
            //        item2.SubItems.Add(oku2["description"].ToString());
            //        item2.SubItems.Add(oku2["isFixible"].ToString());

            //        listViewPerformance.Items.Add(item2);

            //    }

            //}


            ////PERFORMANCE tablosu için veritabanındaki verileri okur
            //baglanti.Open();
            //SqlCommand komut2 = new SqlCommand("select * from PERFORMANCE", baglanti);
            //SqlDataReader oku2 = komut2.ExecuteReader();
            //while (oku2.Read())
            //{
            //    ListViewItem item2 = new ListViewItem(oku2["id"].ToString());
            //    item2.SubItems.Add(oku2["type"].ToString());
            //    item2.SubItems.Add(oku2["parentObject"].ToString());
            //    item2.SubItems.Add(oku2["objectType"].ToString());
            //    item2.SubItems.Add(oku2["object"].ToString());
            //    item2.SubItems.Add(oku2["ratio"].ToString());
            //    item2.SubItems.Add(oku2["description"].ToString());
            //    item2.SubItems.Add(oku2["isFixible"].ToString());

            //    listViewPerformance.Items.Add(item2);

            //}


            //baglanti.Close();

            foreach (ListViewItem item in listViewPerformance.Items)
            {
                ColorManager.AssignColor(item);
            }
            CountListView(listViewPerformance, btnPerformance);

            CountListView(listViewSystemResource, btnSystemResource);




            ////renklendirme
            //foreach (ListViewItem item in listViewPerformance.Items)
            //{

            //    if (item.SubItems[1].Text == "Fragmentation")
            //    {
            //        item.BackColor = Color.FromArgb(255, 252, 131);
            //    }

            //    if (item.SubItems[1].Text == "Unnecessary Object")
            //    {
            //        item.BackColor = Color.FromArgb(143, 184, 237);
            //    }

            //    if (item.SubItems[1].Text == "Wrong Configuration")
            //    {
            //        item.BackColor = Color.FromArgb(224, 30, 55);
            //    }
            //    if (item.SubItems[1].Text == "Low Disk Space")
            //    {
            //        item.BackColor = Color.FromArgb(128, 237, 153);
            //    }
            //    if (item.SubItems[1].Text == "Corruption")
            //    {
            //        item.BackColor = Color.FromArgb(194, 187, 240);
            //    }
            //    CountListView(listViewPerformance, btnPerformance);

            //}



            //    //SYSTEM RESOURCE tablosu için veritabanındaki verileri okur
            //    baglanti.Open();
            //    SqlCommand komut3 = new SqlCommand("select * from SYSTEMRESOURCE", baglanti);
            //    SqlDataReader oku3 = komut3.ExecuteReader();
            //    while (oku3.Read())
            //    {
            //        ListViewItem item3 = new ListViewItem(oku3["id"].ToString());
            //        item3.SubItems.Add(oku3["type"].ToString());
            //        item3.SubItems.Add(oku3["parentObject"].ToString());
            //        item3.SubItems.Add(oku3["objectType"].ToString());
            //        item3.SubItems.Add(oku3["object"].ToString());
            //        item3.SubItems.Add(oku3["ratio"].ToString());
            //        item3.SubItems.Add(oku3["description"].ToString());
            //        item3.SubItems.Add(oku3["isFixible"].ToString());

            //        listViewSystemResource.Items.Add(item3);

            //    }
            //    baglanti.Close();



            ////renklendrime
            //foreach (ListViewItem item in listViewSystemResource.Items)
            //{

            //    if (item.SubItems[1].Text == "Fragmentation")
            //    {
            //        item.BackColor = Color.FromArgb(255, 252, 131);
            //    }

            //    if (item.SubItems[1].Text == "Unnecessary Object")
            //    {
            //        item.BackColor = Color.FromArgb(143, 184, 237);
            //    }

            //    if (item.SubItems[1].Text == "Wrong Configuration")
            //    {
            //        item.BackColor = Color.FromArgb(224, 30, 55);
            //    }
            //    if (item.SubItems[1].Text == "Low Disk Space")
            //    {
            //        item.BackColor = Color.FromArgb(128, 237, 153);
            //    }
            //    if (item.SubItems[1].Text == "Corruption")
            //    {
            //        item.BackColor = Color.FromArgb(194, 187, 240);
            //    }
            //    CountListView(listViewSystemResource, btnSystemResource);
            //}

        }




        private void btnTaskList_Clicked(object sender, EventArgs e)
        {
            tabControls.SelectedTab = tabPageOverall;
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
        //    }
        //}
        bool mousedown;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                int mousex = MousePosition.X - 400;
                int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);


            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (IsFullScreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Normal;
                TopMost = false;
                IsFullScreen = false;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                TopMost = true;
                IsFullScreen = true;
            }
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
            TopMost = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPerformance_Clicked(object sender, EventArgs e)
        {

            tabControls.SelectedTab = tabPagePerformance;
        }
     
        private void btnDataLoss_Clicked(object sender, EventArgs e)
        {
            tabControls.SelectedTab = tabPageDataLoss;

        }
        private bool dataLoaded = false;
        private void btnSystemResource_Clicked(object sender, EventArgs e)
        {
           
           tabControls.SelectedTab = tabPageSystemResource;



            string driveName = @"C:\"; // Kontrol edilecek disk yolunu belirle
            long freeSpace = GetFreeDiskSpace(driveName);

            if (freeSpace > 500 * 1024 * 1024) // 500 MB'ın altında ise
            {
                if (!dataLoaded) // Veriler henüz yüklenmediyse
                {
                    // Veritabanından verileri çek
                    GetDataFromDatabase();
                    dataLoaded = true; // Verilerin yüklendiğini işaretle
                }
                //else
                //{
                //    // Veriler zaten yüklendiği için tekrar yüklemeye gerek yok
                //    MessageBox.Show("Veriler zaten yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
             
            }
            else
            {
                // Yeterli disk alanı var, kullanıcı bilgilendir
                MessageBox.Show("Disk alanı 500 MB'dan fazla! Sistem kaynaklarında sorun yok.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            foreach (ListViewItem item in listViewSystemResource.Items)
            {
                ColorManager.AssignColor(item);
            }

            CountListView(listViewSystemResource, btnSystemResource);


            ////renklendrime
            //foreach (ListViewItem item in listViewSystemResource.Items)
            //{

            //    if (item.SubItems[1].Text == "Fragmentation")
            //    {
            //        item.BackColor = Color.FromArgb(255, 252, 131);
            //    }

            //    if (item.SubItems[1].Text == "Unnecessary Object")
            //    {
            //        item.BackColor = Color.FromArgb(143, 184, 237);
            //    }

            //    if (item.SubItems[1].Text == "Wrong Configuration")
            //    {
            //        item.BackColor = Color.FromArgb(224, 30, 55);
            //    }
            //    if (item.SubItems[1].Text == "Low Disk Space")
            //    {
            //        item.BackColor = Color.FromArgb(128, 237, 153);
            //    }
            //    if (item.SubItems[1].Text == "Corruption")
            //    {
            //        item.BackColor = Color.FromArgb(194, 187, 240);
            //    }
            //    CountListView(listViewSystemResource, btnSystemResource);
            //}


        }


        private long GetFreeDiskSpace(string driveName)
        {
            DriveInfo drive = new DriveInfo(driveName);
            return drive.AvailableFreeSpace;
        }

        private void GetDataFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM SYSTEMRESOURCE"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader oku3 = command.ExecuteReader();

                   
                    while (oku3.Read())
                    {
                        ListViewItem item3 = new ListViewItem(oku3["id"].ToString());
                        item3.SubItems.Add(oku3["type"].ToString());
                        item3.SubItems.Add(oku3["parentObject"].ToString());
                        item3.SubItems.Add(oku3["objectType"].ToString());
                        item3.SubItems.Add(oku3["object"].ToString());
                        item3.SubItems.Add(oku3["ratio"].ToString());
                        item3.SubItems.Add(oku3["description"].ToString());
                        item3.SubItems.Add(oku3["isFixible"].ToString());
                            
                        listViewSystemResource.Items.Add(item3);
                    }

                    oku3.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından veri çekerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    



    //count işlemi
    public void CountListView(ListView listView, ButtonNotifications button)
        {
            button.LabelCount = listView.Items.Count.ToString();
            return;
            int rowCount = 0;

            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems.Count > 0 && !string.IsNullOrEmpty(item.SubItems[1].Text))
                {
                    rowCount++;
                }
            }
            button.LabelCount = rowCount.ToString();


        }

        //All ıssues için count
        public void UpdateTabCount(ButtonNotifications button)
        {
            //Tabcontroldeki tab saysınından bir ekisğini issue sayısı olarak balonvukta verir(-1 olmasının sebebi overall pagei de olması)
            int tabCount = tabControls.TabCount;
            button.LabelCount = (tabCount - 1).ToString();
        }

        //listview selectAll işlemi
        private void SelectAllItems(ListView listView)
        {
            bool isAnyItemSelected = false;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked)
                {
                    isAnyItemSelected = true;
                    break;
                }
            }
            // tüm öğeleri seç
            if (!isAnyItemSelected)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    item.Checked = true;
                }
            }
            //tüm seçimleri kaldır
            else
            {
                foreach (ListViewItem item in listView.Items)
                {
                    item.Checked = false;
                }
            }
        }
        private void btnDataLossCheck_Click(object sender, EventArgs e)
        {
            SelectAllItems(listViewDataLoss);
            listViewDataLoss.Focus();
        }

        private void btnPerformanceCheck_Click(object sender, EventArgs e)
        {
            SelectAllItems(listViewPerformance);
            listViewPerformance.Focus();
        }

        private void btnSystemResourceCeheck_Click(object sender, EventArgs e)
        {
            SelectAllItems(listViewSystemResource);
            listViewSystemResource.Focus();

        }

        private void btnOverallCheck_Click(object sender, EventArgs e)
        {
            SelectAllItems(listViewOverall);
            listViewOverall.Focus();
        }


        //Task list butonunda checklenen satırların sayısını verme
        private int GetCheckItemCount(ListView listView)
        {
            int counter = 0;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked == true)
                {
                    counter++;
                }
                //DoListThing(item, item.Checked);
            }
            int returnValue = 0;
            _listViewManager[listView.Name] = counter;
            foreach (int count in _listViewManager.Values)
            {
                returnValue += count;
            }
            return returnValue;
        }




        //Overall e diğer listview deki satırları ekleyip çıkarma işlemi
        //private void DoListThing(ListViewItem item, bool isChecked)
        //{

        //    string satir = "";
        //    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
        //    {
        //        satir += subItem.Text + " ";
        //    }

        //    OverviewItems.Contains(satir);
        //    if (isChecked)
        //    {
        //        if (!OverviewItems.Contains(satir))
        //        {
        //            OverviewItems.Add(satir);
        //        }
        //    }
        //    else
        //    {
        //        if (OverviewItems.Contains(satir))
        //        {
        //            OverviewItems.Remove(satir);
        //        }
        //    }
        //    //her sefeerinde yeni liste oluşturuyor ? sorun çıkarır mı
        //    listViewOverall.Items.Clear();
        //    foreach (string text in OverviewItems)
        //    {

        //        listViewOverall.Items.Add(text);
        //    }
        // }

        /////////////////////////
        private void UpdateSelectedRowCount(ButtonNotifications button)
        {
            TabPage page = tabControls.SelectedTab;

            foreach (Control cntrl in page.Controls)
            {
                if (cntrl.GetType() == typeof(ListView))
                {
                    button.LabelCount = GetCheckItemCount((cntrl as ListView)).ToString();
                }
                //  GetCheckItemCount(listView);
            }
        }

        //ADD QUEUE İÇİN

        private void UpdateAddQueueCount(ButtonNotifications button)
        {
            TabPage page = tabControls.SelectedTab;

            foreach (Control cntrl in page.Controls)
            {
                if (cntrl.GetType() == typeof(ListView))
                {
                    button.LabelCount = GetAddQueueCheckItemCount((cntrl as ListView)).ToString();
                }
                //  GetCheckItemCount(listView);
            }
        }
        //Add Queue butonunda checklenen satırların sayısını verme ve seçilen satırları Task list listesine yazdırma
        private int GetAddQueueCheckItemCount(ListView listView)
        {

            int counter = 0;
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Checked == true)
                {
                    counter++;
                }
                //  DoListThing(item, item.Checked);
            }
            int returnValue = 0;
            _listViewManager[listView.Name] = counter;
            foreach (int count in _listViewManager.Values)
            {
                returnValue += count;
            }
            return returnValue;
        }



        private void UpdateOverallCount(ButtonNotifications button)
        {
            TabPage page = tabControls.SelectedTab;

            foreach (Control cntrl in page.Controls)
            {
                if (cntrl.GetType() == typeof(ListView))
                {
                    button.LabelCount = GetOverallCheckedItemCount((cntrl as ListView)).ToString();
                }
                //  GetCheckItemCount(listView);
            }
        }
        private int GetOverallCheckedItemCount(ListView listView)
        {
            int counter = 0;
            foreach (ListViewItem item in listView.Items)
            {

                if (item != null)
                {
                    if (item.Checked == true)
                    {
                        counter++;
                    }
                }
                //   DoListThing(item, item.Checked);
            }
            return counter;

        }

        private void listViewDataLoss_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
          // UpdateSelectedRowCount(btnTaskList);
            UpdateAddQueueCount(btnAddQueue);

            ////////////////////////////////////
            /// buton add queue ye tıkladıktan sonra listview overall'e eklemek için 
            if (!_checkedItems.ContainsKey(e.Item))
            {
                _checkedItems.Add(e.Item, e.Item.Checked); 
            }
            else
            {
                _checkedItems[e.Item] = e.Item.Checked; 
            }
            // CheckBox işaret durumu değiştiyse listViewOverall güncelle
            if (!e.Item.Checked)
            {
                foreach (ListViewItem item in listViewOverall.Items)
                {
                    if (item.Text == e.Item.Text)
                    {
                 //       listViewOverall.Items.Remove(item);
                        break;
                    }
                }
                
            }

        }


        private void listViewOverall_ItemChecked_1(object sender, ItemCheckedEventArgs e)
        {
            UpdateOverallCount(btnFixit);
        }

        // addqueue butonuna tıkladıktan sonra listeye eklemek için 
        private void btnAddQueue_Clicked(object sender, EventArgs e)
        {
            UpdateAddQueueCount(btnAddQueue);
            UpdateSelectedRowCount(btnTaskList);
            listViewOverall.Items.Clear();// her seferinde listeyi sıfırdan eklememesi için

            // her öğe için kontrol
            foreach (var pair in _checkedItems)
            {
                // CheckBox işaretliyse ve listViewOverall'de yoksa listViewOverall'e ekle
                if (pair.Value )
                {
                    ListViewItem newItem = (ListViewItem)pair.Key.Clone();

                    newItem.Checked = false;
                    if (!listViewOverall.Items.Contains(newItem)) { 
                    listViewOverall.Items.Add(newItem);
                    }

                    overallItems.Add(newItem);
                    
                }
                // listViewOverall'den kaldır
                //else if (!pair.Value )
                //{
                //  //  listViewOverall.Items.RemoveByKey(pair.Key.Text);
                //    // listViewOverall'den kaldırılan öğeyi overallItems koleksiyonundan kaldırma
                //    ListViewItem removedItem = overallItems.Find(item => item.Text == pair.Key.Text);
                //    listViewOverall.Items.Remove(removedItem);
                //    overallItems.Remove(removedItem);
                //}
                
            }

          //  checkedItems.Clear();

        }
        // listViewOverall'deki öğeleri yeniden yükleme
        private void ReloadOverallItems()
        {
            listViewOverall.Items.Clear();
            listViewOverall.Items.AddRange(overallItems.ToArray());
        }
        private void btnTaskList_Click(object sender, EventArgs e)

        { 
            foreach (ListViewItem item in listViewOverall.Items)
            {
                // item.Selected = false;
                item.Checked = false;
                
            }

          
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
           // controlResizer.ReSizeControl(this, this);
        }

        private void btnPerformance_Load(object sender, EventArgs e)
        {

        }

        private void btnDataLoss_Click(object sender, EventArgs e)
        {

        }
    }
}  
