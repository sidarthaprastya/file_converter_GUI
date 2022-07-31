using Aspose.Cells;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace file_converter
{


    public partial class file_converter : Form
    {

        public const string CppConvertDLL = "csv_to_pdf.dll";
        [DllImport(CppConvertDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void decode_csv(string input_file, string output_file);

        [DllImport(CppConvertDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_csv(string filename);

        [DllImport(CppConvertDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void encode_csv(string input_file, string output_file);

        public static string notification = "";

        private static bool valid_encoded_path, valid_filename, valid_folder_path;
        public file_converter()
        {
            InitializeComponent();
            Aspose.Cells.TxtLoadOptions option = new Aspose.Cells.TxtLoadOptions();
            option.Separator = ',';

            valid_encoded_path = false;
            valid_filename = false;
            valid_folder_path = false;

            btn_convert.Enabled = false;
            combo_conv.SelectedItem = "Decode";
            //option.ConvertDateTimeData = true;
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //string execPath = AppDomain.CurrentDomain.BaseDirectory;
                Debug.WriteLine($"{AppDomain.CurrentDomain.BaseDirectory}csv_to_pdf.dll");
                ofd.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt_path.Text = ofd.FileName;
                }

            }
        }

        private void btn_folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txt_folder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            try
            {
                string folder_path = txt_folder.Text.Replace("\\", "/");

                string input_path = txt_path.Text.Replace("\\", "/");
                //encoded_path;
                //Debug.Write(csv_path);
                //Debug.Write(encoded_path);

                if (combo_conv.SelectedItem == "Decode")
                {
                    string output_path = $"{folder_path}/{txt_filename.Text}_temp.csv";

                    decode_csv(input_path, output_path);

                    Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook($"{output_path}");

                    Worksheet worksheet = workbook.Worksheets[0];

                    Column column = worksheet.Cells.Columns[0];
                    //Style style1 = workbook.CreateStyle();
                    //StyleFlag flag = new StyleFlag();
                    column.Width = 20;

                    workbook.Save($"{txt_folder.Text}\\{txt_filename.Text}.pdf", Aspose.Cells.SaveFormat.Pdf);
                    delete_csv(output_path);

                    notification = $"File is successfully converted at\n{txt_folder.Text}\\{txt_filename.Text}.pdf";
                }
                else
                {
                    string output_path = $"{folder_path}/{txt_filename.Text}.csv";

                    encode_csv(input_path, output_path);
                    notification = $"File is successfully converted at\n{txt_folder.Text}\\{txt_filename.Text}.csv";
                }

                bool popup_loop = true;
                while (popup_loop)
                {
                    popup notif_window = new popup();
                    DialogResult dialogResult = notif_window.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        popup_loop = false;
                    }
                    notif_window.Dispose();
                }


            }
            catch (Exception err)
            {
                notification = err.Message;
                bool popup_loop = true;
                while (popup_loop)
                {
                    popup notif_window = new popup();
                    DialogResult dialogResult = notif_window.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        popup_loop = false;
                    }
                }
            }

        }

        private void txt_path_TextChanged(object sender, EventArgs e)
        {
            if (txt_path.Text.Length != 0)
            {
                valid_encoded_path = true;
            }
            else
            {
                valid_encoded_path = false;
            }
            if (valid_encoded_path && valid_filename && valid_folder_path)
            {
                btn_convert.Enabled = true;
            }
            else
            {
                btn_convert.Enabled = false;
            }
        }


        private void txt_filename_TextChanged(object sender, EventArgs e)
        {
            if (txt_filename.Text.Length != 0)
            {
                valid_filename = true;
            }
            else
            {
                valid_filename = false;
            }
            if (valid_encoded_path && valid_filename && valid_folder_path)
            {
                btn_convert.Enabled = true;
            }
            else
            {
                btn_convert.Enabled = false;
            }
        }

        private void txt_folder_TextChanged(object sender, EventArgs e)
        {
            if (txt_folder.Text.Length != 0)
            {
                valid_folder_path = true;
            }
            else
            {
                valid_folder_path = false;
            }
            if (valid_encoded_path && valid_filename && valid_folder_path)
            {
                btn_convert.Enabled = true;
            }
            else
            {
                btn_convert.Enabled = false;
            }
        }
    }
}
