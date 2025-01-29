using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Examination_System.controller
{
    internal abstract class TableData
    {
        public TableData() { }

        public static void getData(String tableName, string column, string searchText, DataGridView table)
        {
            using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
            {
                if (connection == null)
                    return;

                try
                {
                    using (SqlCommand command = new SqlCommand("search", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@table", tableName);
                        command.Parameters.AddWithValue("@col", column);
                        command.Parameters.AddWithValue("@search_text", searchText);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);
                        table.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        public static void fillComboBoxAndTable(Object obj, string stName, string paramName, int id)
        {
            try
            {
                using (SqlConnection connection = controller.DatabaseConnection.GetConnection())
                {
                    using (SqlCommand command = new SqlCommand(stName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue($"@{paramName}", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (obj is ComboBox comboBox)
                            {
                                while (reader.Read())
                                    if (reader["CourseName"] != DBNull.Value)
                                        comboBox.Items.Add(reader["CourseName"].ToString());
                            }
                            else if (obj is DataGridView dataGridView)
                            {
                                var dataTable = new DataTable();
                                dataTable.Load(reader);
                                dataGridView.DataSource = dataTable;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void generateReport(DataGridView table, int flag)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF file|*.pdf",
                FileName = flag == 1 ? "Students_Grades.pdf" : 
                           flag == 2 ? "Pass_Persentage.pdf" : ".pdf"
            };


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        Document document = new Document();
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);

                        document.Open();


                        iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                        Paragraph title = new Paragraph(
                            flag == 1 ? "Students Grades" :
                            flag == 2 ? "Pass Persentage" : "", 
                        titleFont)
                        {
                            Alignment = Element.ALIGN_CENTER
                        };

                        document.Add(title);
                        document.Add(new Paragraph("\n"));

                        PdfPTable pdfTable = new PdfPTable(table.Columns.Count);

                        foreach (DataGridViewColumn column in table.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                BackgroundColor = new BaseColor(192, 192, 192)
                            };

                            pdfTable.AddCell(headerCell);
                        }

                        foreach (DataGridViewRow row in table.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(new Phrase(cell.Value?.ToString() ?? ""));
                                }
                            }
                        }

                        document.Add(pdfTable);

                        document.Close();
                        writer.Close();
                    }

                    MessageBox.Show("PDF Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
