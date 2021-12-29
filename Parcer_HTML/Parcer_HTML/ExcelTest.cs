using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcer_HTML
{
    public class ConnexionExcel
    {
        public string _pathExcelFile;
        public ExcelQueryFactory _urlConnexion;
        public ConnexionExcel(string path)
        {
            this._pathExcelFile = path;
            this._urlConnexion = new ExcelQueryFactory(_pathExcelFile);
        }
        public string PathExcelFile
        {
            get
            {
                return _pathExcelFile;
            }
        }
        public ExcelQueryFactory UrlConnexion
        {
            get
            {
                return _urlConnexion;
            }
        }
    }

    public class Product
    {
        public int ProductId
        {
            get;
            set;
        }
        public string PartNumber
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }

        public void FuncOne()
        {
            List<string> MassPartNumber = new List<string>();
            string pathToExcelFile = @"D:\TestExcel.xlsx";
            ConnexionExcel ConxObject = new ConnexionExcel(pathToExcelFile);
            //Query a worksheet with a header row (sintax SQL-Like LINQ)
            var query1 = from a in ConxObject.UrlConnexion.Worksheet<Product>("Лист1")
                         select a;
            foreach (var result in query1)
            {
                string products = "{0}";
                //Console.WriteLine(string.Format(products, result.PartNumber));
                MassPartNumber.Add(result.PartNumber);
            }
            for(int i = 0; i < MassPartNumber.Count; i++)
                Console.WriteLine(MassPartNumber[i]);
            
            Console.ReadKey();
        }
    }
}
