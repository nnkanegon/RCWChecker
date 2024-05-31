using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace test1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WriteExcelButton_Click(object sender, EventArgs e)
        {
            string outputFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "test1.xlsx");
            try
            {
                using (ComReleaseManager crm = new ComReleaseManager())
                {
                    dynamic objExcel = crm.Add(Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application")));
                    dynamic objBooks = crm.Add(objExcel.WorkBooks);
                    dynamic objBook = crm.Add(objBooks.Add());
                    dynamic objWorksheets = crm.Add(objBook.Worksheets);
                    dynamic objSheet = crm.Add(objWorksheets("sheet1"));
                    dynamic objRange = crm.Add(objSheet.Range("A1"));
                    objRange.Value = 123;
                    objExcel.DisplayAlerts = false;
                    objBook.SaveAs(outputFileName);
                    objExcel.DisplayAlerts = true;

                    Thread.Sleep(3000);

                    objBook.Close(false);
                    objExcel.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ComReleaseManager.GCCollect();
        }
    }
}
