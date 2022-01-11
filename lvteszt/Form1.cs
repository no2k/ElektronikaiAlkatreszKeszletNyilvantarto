using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lvteszt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateMyListView();
        }

        private void CreateMyListView()
        {
          
            ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
           
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);
            
            
            ListViewItem item1 = new ListViewItem("item1");
           
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            listView1.Items.Add(item1);
            // ListViewItem item1 = new ListViewItem("ez");
            item1 = new ListViewItem("item1");
            item1.SubItems.Add("4");
            item1.SubItems.Add("5");
            item1.SubItems.Add("6");
            listView1.Items.Add(item1);

            // ListViewItem item1 = new ListViewItem("az");
            item1 = new ListViewItem("item1");
            item1.SubItems.Add("7");
            item1.SubItems.Add("8");
            item1.SubItems.Add("9");
            listView1.Items.Add(item1);


            // listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            this.Controls.Add(listView1);
        }
    }
}
