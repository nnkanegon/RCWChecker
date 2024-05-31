using System;
using System.IO;
using System.Reflection;

namespace test2
{
    internal class Program
    {
        static void WriteExcel(dynamic objExcel)
        {
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string outputFileName = Path.Combine(Path.GetDirectoryName(myAssembly.Location), "test2.xlsx");
            using (ComReleaseManager crm = new ComReleaseManager())
            {
                dynamic objBooks = crm.Add(objExcel.WorkBooks);
                dynamic objBook = crm.Add(objBooks.Add());
                dynamic objWorksheets = crm.Add(objBook.Worksheets);
                dynamic objSheet = crm.Add(objWorksheets("sheet1"));
                dynamic objRange = crm.Add(objSheet.Range("A1"));
                objRange.Value = 123;
                objExcel.DisplayAlerts = false;
                objBook.SaveAs(outputFileName);
                objExcel.DisplayAlerts = true;

                objBook.Close(false);
            }
        }

        static void Main(string[] args)
        {
            RCWCheckerConnect.Attach();
            using (ComReleaseManager crm = new ComReleaseManager())
            {
                dynamic objExcel = crm.Add(Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application")));

                RCWCheckerConnect.Dump("pre WriteExcel()");
                WriteExcel(objExcel);
                RCWCheckerConnect.Dump("post WriteExcel()");

                objExcel.Quit();
            }
            ComReleaseManager.GCCollect();
        }
    }
}
