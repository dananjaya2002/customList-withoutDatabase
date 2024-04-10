using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace customList.DAL
{
    internal class ClassDAL
    {
        #region Add Items To Table

        public bool AddItemsToTable(Image img, string title, string description)
        {
            Connection con = new Connection(); //connection class object to access connection string
            if (ConnectionState.Closed == con.connect.State)//check if connection is closed
            {
                con.connect.Open();//open connection
            }

            string query = "insert into Table_Item(Title,Description,Image) values(@title,@description,@image)";//query to insert values into table

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con.connect))
                {
                    cmd.Parameters.AddWithValue("@title", title.Trim());//passing title to query
                    cmd.Parameters.AddWithValue("@description", description.Trim());//passing subtitle to query

                    MemoryStream ms = new MemoryStream();//converting binary Image to binary format to save in database
                    img.Save(ms, img.RawFormat);//save image to memory stream
                    byte[] imgdata = ms.ToArray();//convert image to byte array
                    cmd.Parameters.AddWithValue("@image", imgdata);//passing image to query

                    cmd.ExecuteNonQuery();//execute query

                }
                return true;
            }
            catch
            {
                throw;
            }



        }


        #endregion

        #region Read Items In Table

        public DataTable ReadItemsTable()
        {
            Connection con = new Connection(); //connection class object to access connection string
            if (ConnectionState.Closed == con.connect.State)//check if connection is closed
            {
                con.connect.Open();//open connection
            }

            string query = "select * from Table_Item";//query to select all values from table

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con.connect))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();//create datatable to store values
                        da.Fill(dt);//fill datatable with values from database
                        return dt;//return datatable
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
