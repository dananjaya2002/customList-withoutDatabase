using customList.BLL;
using customList.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateItems();
        }

        private void PopulateItems()
        {
            ClassBLL objbll = new ClassBLL();//creating object of ClassBLL to access function

            DataTable dt = objbll.GetItems();//getting data from database

            
            if (dt != null &&  dt.Rows.Count > 0)
            {
                //populating here
                ListItem[] listItems = new ListItem[dt.Rows.Count];
                for (int i = 0; i < 1; i++)
                {
                    //this loop runs untill the records ends in databse
                    foreach (DataRow row in dt.Rows)//reads rows one by one
                    {
                        listItems[i] = new ListItem();//creating object of user control

                        //recovering binary formatted image coming from database to normal image
                        MemoryStream ms = new MemoryStream((byte[])row["Image"]);
                        listItems[i].Icon = new Bitmap(ms);

                        //get title & subtitle from current row in a data table and set to user control
                        listItems[i].Title = row["Title"].ToString();
                        listItems[i].Message = row["Description"].ToString();
                        //add flowoutlayout
                        if (flowLayoutPanel1.Controls.Count < 0)
                        {
                            flowLayoutPanel1.Controls.Clear();
                        }
                        else
                        {
                            flowLayoutPanel1.Controls.Add(listItems[i]);
                        }
                    }
                }
                
            }

            
        }

        #region Form2
        private void addItems_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        } 
        #endregion
    }
}
