using customList.DAL;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customList.BLL
{
    internal class ClassBLL
    {
        #region save Items
        public bool SaveItems(Image img, string title, string Description)
        {
            try
            {
                ClassDAL objdal = new ClassDAL();  //data access layer class object to handle functions
                return objdal.AddItemsToTable(img, title, Description);//passing values to data access layer function
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return false;
            }
        }


        #endregion

        #region Get Items
        public DataTable GetItems()
        {
            try
            {
                ClassDAL objdal = new ClassDAL();  //data access layer class object to access functions
                return objdal.ReadItemsTable();
            }
            catch (Exception e)
            {
                DialogResult result = MessageBox.Show(e.Message.ToString());
                return null;
            }
        }


        #endregion
    }
}
