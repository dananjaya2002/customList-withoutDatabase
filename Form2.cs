using customList.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customList
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        #region Upload Btn
        private void upload_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openlg = new OpenFileDialog();
            if (openlg.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openlg.FileName);
                pb_upload.Image = image;
            }
        }

        #endregion

        #region Save Btn
        private void save_btn_Click(object sender, EventArgs e)
        {
            ClassBLL objbll = new ClassBLL();

            /*
             * sending image, title &subtitle to function
             * objbll.SaveItems(image,title,subtitle);
             *function returns true if record save successfully
             */

            if (objbll.SaveItems(pb_upload.Image, txttitle.Text, txtdescription.Text))
            {
                MessageBox.Show("Record Saved Successfully");
            }
            else
            {
                MessageBox.Show("Record Not Saved");
            }
        }

        #endregion

        #region Back Btn
        private void back_btn_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        } 
        #endregion
    }
}
