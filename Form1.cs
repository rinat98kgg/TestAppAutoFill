using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.IO;
using System.Reflection;

namespace TestAppAutoFill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ANN, textMessage;
            ANN = txtANN.Text;


            string conStr = @"Data Source=LAPTOP-E5C7TC4D\SQLEXPRESS;Initial Catalog=dbTest;User ID=sa;Password=123";

            string sqlExpression = "SELECT * FROM Clients WHERE SocialNumber = " + ANN;

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string file, resfile, resultFileName;
                    string currentDate = DateTime.Now.ToShortDateString();
                    string fileName = "example.xlsx";

                    file = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Templete\\" + fileName);

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWb = xlApp.Workbooks.Open(file);
                    Excel.Worksheet xlSht = xlWb.Sheets[1];
                    Excel.Range Rng; //диапазон ячеек

                    //string textToFind = "[ID]";
                    //Rng = xlSht.Cells.Find(textToFind, Type.Missing, Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart); //осуществляем поиск на листе

                    //if (Rng != null)
                    //{
                    //    MessageBox.Show("Текст: '" + textToFind + "' найден в ячейке: " + Rng.Address, "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    Rng.Select();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Текст: '" + textToFind + "' на листе не найден!", "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    xlSht.Cells[8, "B"].NumberFormat = "0";
                    xlSht.Cells[4, "I"].NumberFormat = "0";
                    xlSht.get_Range("B8", "B8").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlSht.get_Range("I4", "I4").Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlSht.Cells[8, "B"].ColumnWidth = 17;
                    xlSht.Cells[4, "I"].ColumnWidth = 17;

                    xlSht.Cells[1, "B"].Value = currentDate;
                    while (reader.Read())
                    {
                        //Rng.Address = reader.GetValue(0);
                        xlSht.Cells[3, "B"].Value = reader.GetValue(0);
                        xlSht.Cells[4, "B"].Value = reader.GetValue(1);
                        xlSht.Cells[5, "B"].Value = reader.GetValue(2);
                        xlSht.Cells[6, "B"].Value = reader.GetValue(3);
                        xlSht.Cells[7, "B"].Value = reader.GetValue(4);
                        xlSht.Cells[8, "B"].Value = reader.GetValue(5);

                        xlSht.Cells[4, "D"].Value = reader.GetValue(0);
                        xlSht.Cells[4, "E"].Value = reader.GetValue(1);
                        xlSht.Cells[4, "F"].Value = reader.GetValue(2);
                        xlSht.Cells[4, "G"].Value = reader.GetValue(3);
                        xlSht.Cells[4, "H"].Value = reader.GetValue(4);
                        xlSht.Cells[4, "I"].Value = reader.GetValue(5);
                    }

                    resultFileName = "result_" + ANN + ".xlsx";
                    resfile = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Result\\" + resultFileName);


                    if (!Directory.Exists(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Result\\")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Result\\"));
                    }

                    xlWb.SaveAs(resfile, Excel.XlFileFormat.xlWorkbookDefault,
                        Type.Missing, Type.Missing,
                        false, false,
                        Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);


                    xlApp.Quit();

                    textMessage = "Путь сохранения файла \n" + resfile;
                }
                else textMessage = "Нет клиента с таким ИНН";
                reader.Close();

            }
            MessageBox.Show(textMessage);
        }
    }
}
