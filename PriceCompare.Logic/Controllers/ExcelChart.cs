using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace PriceCompare.Logic.Controllers
{
    public class ExcelChart
    {

        public bool CreateCompareExcelChart(List<Tuple<string, string, double>> cheapestStoreOfChains)
        {
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp= new Excel.Application(); ;
            Excel.Workbook xlWorkBook= xlApp.Workbooks.Add(misValue);
            Excel.Worksheet xlWorkSheet= (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //add data 
            xlWorkSheet.Cells[1, 1] = "";
            for (int i = 0; i < cheapestStoreOfChains.Count; i++)
            {
                xlWorkSheet.Cells[1, 2 + i] = cheapestStoreOfChains[i].Item1;
                xlWorkSheet.Cells[2, 2 + i] = cheapestStoreOfChains[i].Item3.ToString();
            }


            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = myChart.Chart;

            Excel.Range chartRange = xlWorkSheet.get_Range("A1", "D2");
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;


            xlWorkBook.SaveAs(Environment.CurrentDirectory + @"\CompareChart.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //chartPage.Export(Environment.CurrentDirectory + @"\CompareChart.bmp", "BMP", misValue);
            
            xlWorkBook.Close(0);
            //xlWorkBook.Close(true, misValue, misValue);
            
            xlApp.Quit();

            try
            {

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch (Exception)
            {

                return false;
            }

            //MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
            return true;
        }



        public Bitmap LoadExcelCharImage()
        {
            Bitmap image = null;
            try
            {
                image = new Bitmap(Environment.CurrentDirectory + @"\CompareChart.bmp");
                //image = (Bitmap)Image.FromFile(Environment.CurrentDirectory + @"\CompareChart.bmp", true);


            }
            catch (Exception)
            {

            }
            finally
            {
                GC.Collect();
            }

            return image;
        }
        
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw;
                // Debug.WriteLine("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}
