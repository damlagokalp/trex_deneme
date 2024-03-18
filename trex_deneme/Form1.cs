using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

    public partial class Form1 : Form
    {
        List<ListViewItem> overallItems = new List<ListViewItem>();
        private Dictionary<ListViewItem, bool> checkedItems = new Dictionary<ListViewItem, bool>();
        private List<string> OverviewItems = new List<string>();
        private Dictionary<string, int> _ListViewManager = new Dictionary<string, int>();
        int totalSelectedRowCount = 0;
        private bool IsFullScreen = false;
        public Form1()
        {
            InitializeComponent();

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(local); Initial Catalog=TREXOPTIMIZER; Integrated Security=false;user id=sa;password=123");




        private void Form1_Load(object sender, EventArgs e)
        {
            _ListViewManager[listViewDataLoss.Name] = 0;
            _ListViewManager[listViewPerformance.Name] = 0;
            _ListViewManager[listViewSystemResource.Name] = 0;

            UpdateTabCount(btnAllIssues);
            // UpdateSelectedRowCount(btnTaskList);
            // UpdateFixitCount(btnFixit);



            //tabpageler gizlendi
            tabControls.Appearance = TabAppearance.FlatButtons;
            tabControls.ItemSize = new Size(0, 1);
            tabControls.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tabControls.TabPages)
            {
                tab.Text = "";

            }

            //DATALOSS tablosu için veritabanındaki verileri okur

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from DATALOSS", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
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
            baglanti.Close();
            //Renklendirme
            foreach (ListViewItem item in listViewDataLoss.Items)
            {

                if (item.SubItems[1].Text == "Fragmentation")
                {
                    item.BackColor = Color.FromArgb(255, 252, 131);
                }

                if (item.SubItems[1].Text == "Unnecessary Object")
                {
                    item.BackColor = Color.FromArgb(143, 184, 237);
                }

                if (item.SubItems[1].Text == "Wrong Configuration")
                {
                    item.BackColor = Color.FromArgb(224, 30, 55);
                }
                if (item.SubItems[1].Text == "Low Disk Space")
                {
                    item.BackColor = Color.FromArgb(128, 237, 153);
                }
                if (item.SubItems[1].Text == "Corruption")
                {
                    item.BackColor = Color.FromArgb(194, 187, 240);
                }
                CountListView(listViewDataLoss, btnDataLoss);

            }

            //PERFORMANCE tablosu için veritabanındaki verileri okur
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from PERFORMANCE", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem item2 = new ListViewItem(oku2["id"].ToString());
                item2.SubItems.Add(oku2["type"].ToString());
                item2.SubItems.Add(oku2["parentObject"].ToString());
                item2.SubItems.Add(oku2["objectType"].ToString());
                item2.SubItems.Add(oku2["object"].ToString());
                item2.SubItems.Add(oku2["ratio"].ToString());
                item2.SubItems.Add(oku2["description"].ToString());
                item2.SubItems.Add(oku2["isFixible"].ToString());

                listViewPerformance.Items.Add(item2);

            }


            baglanti.Close();
            //renklendirme
            foreach (ListViewItem item in listViewPerformance.Items)
            {

                if (item.SubItems[1].Text == "Fragmentation")
                {
                    item.BackColor = Color.FromArgb(255, 252, 131);
                }

                if (item.SubItems[1].Text == "Unnecessary Object")
                {
                    item.BackColor = Color.FromArgb(143, 184, 237);
                }

                if (item.SubItems[1].Text == "Wrong Configuration")
                {
                    item.BackColor = Color.FromArgb(224, 30, 55);
                }
                if (item.SubItems[1].Text == "Low Disk Space")
                {
                    item.BackColor = Color.FromArgb(128, 237, 153);
                }
                if (item.SubItems[1].Text == "Corruption")
                {
                    item.BackColor = Color.FromArgb(194, 187, 240);
                }
                CountListView(listViewPerformance, btnPerformance);

            }
            //SYSTEM RESOURCE tablosu için veritabanındaki verileri okur
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from SYSTEMRESOURCE", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
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
            baglanti.Close();
            //renklendrime
            foreach (ListViewItem item in listViewSystemResource.Items)
            {

                if (item.SubItems[1].Text == "Fragmentation")
                {
                    item.BackColor = Color.FromArgb(255, 252, 131);
                }

                if (item.SubItems[1].Text == "Unnecessary Object")
                {
                    item.BackColor = Color.FromArgb(143, 184, 237);
                }

                if (item.SubItems[1].Text == "Wrong Configuration")
                {
                    item.BackColor = Color.FromArgb(224, 30, 55);
                }
                if (item.SubItems[1].Text == "Low Disk Space")
                {
                    item.BackColor = Color.FromArgb(128, 237, 153);
                }
                if (item.SubItems[1].Text == "Corruption")
                {
                    item.BackColor = Color.FromArgb(194, 187, 240);
                }
                CountListView(listViewSystemResource, btnSystemResource);
            }
        }
        private void btnTaskList_Clicked(object sender, EventArgs e)
        {
            tabControls.SelectedTab = tabPageOverall;
        }
        public void ReSizeControl(Control control, Control TargetControl)
        {
            if (IsControlResizable(control))
            {
                int referenceWidth = control.Width;
                int referenceHeight = 720;
                float widthRatio = ((float)TargetControl.Width) / (float)referenceWidth;
                float heightRatio = ((float)Screen.PrimaryScreen.Bounds.Height / (float)referenceHeight);
                SizeF size = new SizeF();
                size.Width = widthRatio;
                size.Height = heightRatio;
                control.Scale(size);
                control.Tag = 90;
                ResizeFont(control, widthRatio);

            }
        }
        private void ResizeFont(Control parentControl, float ratio)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control.HasChildren)
                {
                    ResizeFont(control, ratio);
                }
                if (control.Font != null)
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * ratio, control.Font.Style);
                }
            }
        }
        public bool IsControlResizable(Control control)
        {
            if (control.Tag == null)
            {
                return true;
            }
            else
            {
                if (control.Tag.ToString() == "99")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
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

        private void btnSystemResource_Clicked(object sender, EventArgs e)
        {
            tabControls.SelectedTab = tabPageSystemResource;
        }

        //count işlemi
        public void CountListView(ListView listView, ButtonNotifications button)
        {
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
            _ListViewManager[listView.Name] = counter;
            foreach (int count in _ListViewManager.Values)
            {
                returnValue += count;
            }
            return returnValue;
        }




        //Overall e diğer listview deki satırları ekleyip çıkarma işlemi
        private void DoListThing(ListViewItem item, bool isChecked)
        {

            string satir = "";
            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                satir += subItem.Text + " ";
            }

            OverviewItems.Contains(satir);
            if (isChecked)
            {
                if (!OverviewItems.Contains(satir))
                {
                    OverviewItems.Add(satir);
                }
            }
            else
            {
                if (OverviewItems.Contains(satir))
                {
                    OverviewItems.Remove(satir);
                }
            }
            //her sefeerinde yeni liste oluşturuyor ? sorun çıkarır mı
            listViewOverall.Items.Clear();
            foreach (string text in OverviewItems)
            {

                listViewOverall.Items.Add(text);
            }
        }

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
            _ListViewManager[listView.Name] = counter;
            foreach (int count in _ListViewManager.Values)
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
            if (!checkedItems.ContainsKey(e.Item))
            {
                checkedItems.Add(e.Item, e.Item.Checked); // CheckBox durumunu sakla
            }
            else
            {
                checkedItems[e.Item] = e.Item.Checked; // CheckBox durumunu güncelle
            }
            // Eğer CheckBox işaret durumu değiştiyse, listViewOverall'deki ilgili öğeyi güncelle
            if (!e.Item.Checked)
            {
                foreach (ListViewItem item in listViewOverall.Items)
                {
                    if (item.Text == e.Item.Text)
                    {
                        listViewOverall.Items.Remove(item);
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
            //UpdateAddQueueCount(btnAddQueue);
            UpdateSelectedRowCount(btnTaskList);
            UpdateOverallCount(btnFixit);

            // her öğe için kontrol
            foreach (var pair in checkedItems)
            {
                // Eğer CheckBox işaretliyse ve listViewOverall'de yoksa, öğeyi listViewOverall'e ekle
                if (pair.Value && !listViewOverall.Items.ContainsKey(pair.Key.Text))
                {
                    ListViewItem newItem = (ListViewItem)pair.Key.Clone();
                    listViewOverall.Items.Add(newItem);
                    newItem.Checked = false;
                    
                    overallItems.Add(newItem);
                }
                // listViewOverall'den kaldır
                else if (!pair.Value && listViewOverall.Items.ContainsKey(pair.Key.Text))
                {
                    listViewOverall.Items.RemoveByKey(pair.Key.Text);
                    // listViewOverall'den kaldırılan öğeyi overallItems koleksiyonundan kaldırma
                    ListViewItem removedItem = overallItems.Find(item => item.Text == pair.Key.Text);
                    overallItems.Remove(removedItem);
                }
            }
           

            // Arka plandaki seçili öğelerin temizlenmesi
            checkedItems.Clear();

        }
        // listViewOverall'deki öğeleri yeniden yüklemek için bir yöntem
        private void ReloadOverallItems()
        {
            listViewOverall.Items.Clear();
            listViewOverall.Items.AddRange(overallItems.ToArray());
        }
        private void btnTaskList_Click(object sender, EventArgs e)

        {  //// listViewOverall'de seçilen satırların sabit kalması ve checkboxlarının işaretlenmemesi

            foreach (ListViewItem item in listViewOverall.Items)
            {
                // item.Selected = false;
                item.Checked = false;
            }

          
        }

        
    }
}  
