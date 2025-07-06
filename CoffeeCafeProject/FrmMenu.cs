using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CoffeeCafeProject
{
    public partial class FrmMenu : Form
    {
        //สร้างตัวแปรเก็บรูปที่แปลงเป็น Binary/Byte Array เอาไว้บันทึก DB
        byte[] menuImage;
        public FrmMenu()
        {
            InitializeComponent();
        }

        private Image convertByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                // อาจเกิดขึ้นถ้า byte array ไม่ใช่ข้อมูลรูปภาพที่ถูกต้อง
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                return null;
            }
        }

        private byte[] convertImageToByteArray(Image image, ImageFormat imageFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, imageFormat);
                return ms.ToArray();
            }
        }


        private void getAllMenuToListView()
        {
            //Connect String เพื่อติดต่อไปยังฐานข้อมูล
            string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=coffee_cafe_db;Trusted_Connection=True;";
            //สร้าง Connection ไปยังฐานข้อมูล
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open(); //เปิดการเชื่อมต่อไปยังฐานข้อมูล

                    //การทำงานกับตารางในฐานข้อมูล (SELECT, INSERT, UPDATE, DELETE)
                    //สร้างคำสั่ง SQL ในที่นี้คือ ดึงข้อมูลทั้งหมดจากตาราง menu_tb
                    string strSQL = "SELECT  menuId, menuName, menuPrice, menuImage FROM menu_tb";

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {
                        //ดึง
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        //ตั้งค่า ListView
                        lvShowAllMenu.Items.Clear();
                        lvShowAllMenu.Columns.Clear();
                        lvShowAllMenu.FullRowSelect = true;
                        lvShowAllMenu.View = View.Details;

                        //ตั้งค่าการแสดงรูปใน ListView
                        if (lvShowAllMenu.SmallImageList == null)
                        {
                            lvShowAllMenu.SmallImageList = new ImageList();
                            lvShowAllMenu.SmallImageList.ImageSize = new Size(50, 50);
                            lvShowAllMenu.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
                        }
                        lvShowAllMenu.SmallImageList.Images.Clear();

                        //กำหนดรายละเอียดของ Column ใน ListView
                        lvShowAllMenu.Columns.Add("รูปเมนู", 80, HorizontalAlignment.Left);
                        lvShowAllMenu.Columns.Add("รหัสเมนู", 80, HorizontalAlignment.Left);
                        lvShowAllMenu.Columns.Add("ชื่อเมนู", 150, HorizontalAlignment.Left);
                        lvShowAllMenu.Columns.Add("ราคาเมนู", 80, HorizontalAlignment.Left);


                        //Loop วนเข้าไปใน DataTable
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            ListViewItem item = new ListViewItem(); //สร้าง item เพื่อเก็บแต่ละข้อมูลในแต่ละรายการ

                            //เอารูปใส่ใน item
                            Image menuImage = null;
                            if (dataRow["menuImage"] != DBNull.Value)
                            {
                                byte[] imgByte = (byte[])dataRow["menuImage"];
                                //แปลงข้อมูลรูปจากฐานข้อมูลซึ่งเป็น Binary ให้เป็นรูป
                                menuImage = convertByteArrayToImage(imgByte);
                            }
                            string imageKey = null;
                            if (menuImage != null)
                            {
                                imageKey = $"menu_{dataRow["menuId"]}";
                                lvShowAllMenu.SmallImageList.Images.Add(imageKey, menuImage);
                                item.ImageKey = imageKey;
                            }
                            else
                            {
                                item.ImageIndex = -1;
                            }

                            //เอาแต่ละรายการใส่ใน item
                            item.SubItems.Add(dataRow["menuId"].ToString());
                            item.SubItems.Add(dataRow["menuName"].ToString());
                            item.SubItems.Add(dataRow["menuPrice"].ToString());


                            //เอาข้อมูลใน item
                            lvShowAllMenu.Items.Add(item);



                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("พบข้อผิดพลาด กรุณาลองใหม่หรือติอต่อ IT :" + ex.Message);
                }

            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            getAllMenuToListView();
            pbMenuImage.Image = null;
            tbMenuId.Clear();
            tbMenuName.Clear();
            tbMenuPrice.Clear();
            btSave.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;
        }

        private void pbMenuImage_Click(object sender, EventArgs e)
        {
            //เปิด File Dialog ให้เลือกรูปโดยฟิวเตอร์เฉพาะไฟล์ jpg/png
            //แล้วนำรูปที่เลือกไปแสดงที่ pcbProImage
            //แล้วก็แปลงเป็น Binary/Byte เก็บในตัวแปรเพื่อเอาไว้บันทึกลง DB
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //เอารูปที่เลือกไปแสดงที่ pcbProImage
                pbMenuImage.Image = Image.FromFile(openFileDialog.FileName);
                //ตรวจสอบ Format ของรูป แล้วส่งรูปไปแปลงเป็น Binary/Byte เก็บในตัวแปร
                if (pbMenuImage.Image.RawFormat == ImageFormat.Jpeg)
                {
                    menuImage = convertImageToByteArray(pbMenuImage.Image, ImageFormat.Jpeg);
                }
                else
                {
                    menuImage = convertImageToByteArray(pbMenuImage.Image, ImageFormat.Png);
                }
            }
        }
        private void showWarningMSG(string msg)
        {
            MessageBox.Show(msg, "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (menuImage == null)
            {
                showWarningMSG("เลือกรูปเมนูด้วย...");
            }
            else if (tbMenuName.Text.Trim() == "")
            {
                showWarningMSG("ป้อนชื่อสินค้าด้วย...");
            }
            else if (tbMenuPrice.Text.Trim() == "")
            {
                showWarningMSG("ป้อนราคาสินค้าด้วย...");
            }
            else
            {
                //บันทึกฐานข้อมูล
                //Connect String เพื่อติดต่อไปยังฐานข้อมูล
                string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=coffee_cafe_db;Trusted_Connection=True;";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        string countSQL = "SELECT COUNT(*) FROM menu_tb";
                        using (SqlCommand countCommand = new SqlCommand(countSQL, sqlConnection))
                        {
                            int rowCount = (int)countCommand.ExecuteScalar();
                            if (rowCount == 10)
                            {
                                showWarningMSG("เมนูมีได้แค่10เมนูเท่านัน้ หากจะเพิ่มจำเป็นต้องลบของเก่าออกก่อน");
                                return;
                            }
                        }

                        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(); // ใช้กับ Insert/update/delete

                        //คำสั่ง SQl
                        string strSQL = "INSERT INTO menu_tb (menuName, menuPrice, menuImage) " +
                                        "VALUES (@menuName, @menuPrice, @menuImage)";

                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {

                            sqlCommand.Parameters.Add("@menuName", SqlDbType.NVarChar, 100).Value = tbMenuName.Text;
                            sqlCommand.Parameters.Add("@menuPrice", SqlDbType.Float).Value = float.Parse(tbMenuPrice.Text);
                            sqlCommand.Parameters.Add("@menuImage", SqlDbType.Image).Value = menuImage;


                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();

                            MessageBox.Show("บันทึกเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // update list view แล้วเคลียหน้าจอ
                            getAllMenuToListView();
                            menuImage = null;
                            pbMenuImage.Image = null;
                            tbMenuId.Clear();
                            tbMenuName.Clear();
                            tbMenuPrice.Clear();
                        }

                    }
                    catch (Exception ex)

                    {
                        MessageBox.Show("พบข้อผิดพลาด กรุณาลองใหม่หรือติอต่อ IT: " + ex.Message);
                    }
                }
            }
        }
        private void tbMenuPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // อนุญาตให้กด backspace ได้
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // อนุญาตเฉพาะตัวเลข 0-9
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // อนุญาตให้พิมพ์จุด (.) ได้แค่จุดเดียว
            if (e.KeyChar == '.')
            {
                if (textBox.Text.Contains("."))
                {
                    e.Handled = true; // ป้องกันการพิมพ์จุดซ้ำ
                }
                return;
            }

            // ถ้าไม่ใช่ตัวเลขหรือจุด ให้ปฏิเสธการพิมพ์
            e.Handled = true;
        }

        private void lvShowAllMenu_ItemActivate(object sender, EventArgs e)
        {
            //เอาข้อมูลของรายการที่เลือกไปแสดงที่หน้าจอ แล้วปุ่มบันทึกใช้งานไม่ได้ แก้ไขกับลบใช้งานได้
            tbMenuId.Text = lvShowAllMenu.SelectedItems[0].SubItems[1].Text;
            tbMenuName.Text = lvShowAllMenu.SelectedItems[0].SubItems[2].Text;
            tbMenuPrice.Text = lvShowAllMenu.SelectedItems[0].SubItems[3].Text;

            //เอารูปจาก listView มาแสดงที่หน้าจอ
            var item = lvShowAllMenu.SelectedItems[0];
            if (!String.IsNullOrEmpty(item.ImageKey) && lvShowAllMenu.SmallImageList.Images.ContainsKey(item.ImageKey))
            {
                pbMenuImage.Image = lvShowAllMenu.SmallImageList.Images[item.ImageKey];
            }
            else
            {
                pbMenuImage.Image = null;
            }

            btSave.Enabled = false;
            btUpdate.Enabled = true;
            btDelete.Enabled = true;

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            //ถามผู็ใช้ก่อนว่าต้องการลบหรือไม่
            if (MessageBox.Show("ต้องการลบเมนูหรือไม่", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ลบออกจาก Detabase
                //ลบข้อมูลสินค้าออกจากตารางใน DB เงื่อนไขคือ menuId  
                //กำหนด Connect String เพื่อติดต่อไปยังฐานข้อมูล
                string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=coffee_cafe_db;Trusted_Connection=True;";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(); //ใชกับ Insert/update/delete

                        //คำสั่ง SQL
                        string strSQL = "DELETE FROM menu_tb WHERE menuId=@menuId";

                        //กำหนดค่าให้กับ SQL Parameter และสั่งให้คำสั่ง SQL ทำงาน แล้วมีข้อความแจ้งเมื่อทำงานสำเร็จ
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
                            // กำหนดค่าให้กับ SQL Parameter
                            sqlCommand.Parameters.Add("@menuId", SqlDbType.Int).Value = int.Parse(tbMenuId.Text);

                            //สั่งให้คำสั่ง SQL ทำงาน
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();

                            //ข้อความแจ้งเมื่อทำงานสำเร็จ
                            MessageBox.Show("ลบเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //ปิดหน้าจอฟอร์มนี้ไป
                            getAllMenuToListView();
                            menuImage = null;
                            pbMenuImage.Image = null;
                            tbMenuId.Clear();
                            tbMenuName.Clear();
                            tbMenuPrice.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาด กรุณาลองใหม่หรือติดต่อ IT : " + ex.Message);
                    }
                }

            }
        }



        private void btUpdate_Click(object sender, EventArgs e)
        {
            //Validate UI ก่อนเหมือนกับกดปุ่ม บันทึก (INSERT)
            if (tbMenuName.Text.Trim() == "") //tbMenuName.Text.Length == 0
            {
                showWarningMSG("ป้อนชื่อสินค้าด้วย...");
            }
            else if (tbMenuPrice.Text.Trim() == "") //tbMenuName.Text.Length == 0
            {
                showWarningMSG("ป้อนราคาสินค้าด้วย...");
            }
            else
            {
                //บันทึกลงฐานข้อมูล
                //กำหนด Connect String เพื่อติดต่อไปยังฐานข้อมูล
                string connectionString = @"Server=DESKTOP-9U4FO0V\SQLEXPRESS;Database=coffee_cafe_db;Trusted_Connection=True;";
                //สร้าง Connection ไปยังฐานข้อมูล
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    try
                    {
                        sqlConnection.Open();

                        SqlTransaction sqlTransaction = sqlConnection.BeginTransaction(); //ใชกับ Insert/update/delete

                        //คำสั่ง SQL จะมี 2 แบบคือ แบบแก้รูป กับไม่แก้รูป
                        string strSQL = "";
                        if (menuImage == null)
                        {//ไม่แก้รูป
                            strSQL = "UPDATE  menu_tb  SET  menuName=@menuName, menuPrice=@menuPrice  " +
                                     "WHERE  menuId=@menuId";
                        }
                        else
                        {//แก้รูป
                            strSQL = "UPDATE  menu_tb  SET  menuName=@menuName, menuPrice=@menuPrice, menuImage=@menuImage  " +
                                     "WHERE  menuId=@menuId";
                        }

                        //กำหนดค่าให้กับ SQL Parameter และสั่งให้คำสั่ง SQL ทำงาน แล้วมีข้อความแจ้งเมื่อทำงานสำเร็จ
                        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection, sqlTransaction))
                        {
                            // กำหนดค่าให้กับ SQL Parameter
                            sqlCommand.Parameters.Add("@menuId", SqlDbType.Int).Value = int.Parse(tbMenuId.Text);
                            sqlCommand.Parameters.Add("@menuName", SqlDbType.NVarChar, 100).Value = tbMenuName.Text;
                            sqlCommand.Parameters.Add("@menuPrice", SqlDbType.Float).Value = float.Parse(tbMenuPrice.Text);
                            if (menuImage != null)
                            {
                                sqlCommand.Parameters.Add("@menuImage", SqlDbType.Image).Value = menuImage;
                            }

                            //สั่งให้คำสั่ง SQL ทำงาน
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();

                            //ข้อความแจ้งเมื่อทำงานสำเร็จ
                            MessageBox.Show("แก้ไขเรียบร้อยแล้ว", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //อัปเดจ ListView และเคลียหน้าจอ
                            getAllMenuToListView();
                            menuImage = null;
                            pbMenuImage.Image = null;
                            tbMenuId.Clear();
                            tbMenuName.Clear();
                            tbMenuPrice.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("พบข้อผิดพลาด กรุณาลองใหม่หรือติดต่อ IT : " + ex.Message);
                    }
                }
            }
        }


        private void btCancel_Click(object sender, EventArgs e)
        {
            getAllMenuToListView();
            menuImage = null;
            pbMenuImage.Image = null;
            tbMenuId.Clear();
            tbMenuName.Clear();
            tbMenuPrice.Clear();
            btSave.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            getAllMenuToListView();
            menuImage = null;
            pbMenuImage.Image = null;
            tbMenuId.Clear();
            tbMenuName.Clear();
            tbMenuPrice.Clear();
            btSave.Enabled = true;
            btUpdate.Enabled = false;
            btDelete.Enabled = false;
        }
    }
}
