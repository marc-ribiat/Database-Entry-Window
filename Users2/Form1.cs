using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Users2
{
    public partial class Form1 : Form
    {
        //variables
        List<ListViewItem> users = new List<ListViewItem>();


        public Form1()
        {
            InitializeComponent();
        }

        //when a new row is highlighted
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            switch (e.Node.Text)                            
            {
                case ("Users"):                  
                    listView1.Items.AddRange(listToArray());
                    break;
                case("Groups"):
                    ListViewItem groupItem = new ListViewItem();
                    groupItem.Text = "Dummy Group";
                    groupItem.ImageIndex = 6;
                    listView1.Items.Add(groupItem);
                    ListViewItem.ListViewSubItem descriptionItem = new ListViewItem.ListViewSubItem();
                    descriptionItem.Text = "Dummy Link";
                    groupItem.SubItems.Add(descriptionItem);
                    descriptionItem = new ListViewItem.ListViewSubItem();
                    descriptionItem.Text = "This link will do nothing so dont bother.";
                    groupItem.SubItems.Add(descriptionItem);
                    break;

            }

        }
       //under view choose small icon
        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.SmallIcon;
        }
        //under view choose details
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
        }

        //right click on the user node in treeview and select new user
        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            createNewUser();
        }
        //top menu bar under file > new user
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            createNewUser();
        }
        //this method should create a new user in the users listview
        private void createNewUser()
        {
            listView1.Items.Clear();

            String name = "moshe";
            

            ListViewItem lvi = new ListViewItem();
            lvi.Text = name;
            if (users.Count < 1)
            {
                lvi.ImageIndex = 4;
            }
            else
            {
                lvi.ImageIndex = 5;
            }
            users.Add(lvi);
            listView1.Items.AddRange(listToArray());
        }
        //change the List of users to a listviewitem array to pass to range method
        private ListViewItem[] listToArray()
        {
            ListViewItem[] usersArray = new ListViewItem[users.Count];
            int i = 0;
            foreach (ListViewItem lvi in users)
            {
                usersArray[i] = lvi;
                i++;
            }
            return usersArray;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


     }
}
