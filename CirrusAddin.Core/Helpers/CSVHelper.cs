using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CirrusAddin.Core.Helpers
{
    public class CSVHelper
    {
        public static string GenerateCSVFromData(List<string> headers, List<List<object>> values)
        {
            string csvLines = "";
            for(int i = 0; i < headers.Count; ++i)
            {
                csvLines += headers[i];
                if (i != headers.Count - 1) csvLines += ",";
                else csvLines += Environment.NewLine;
            }

            //prep a data as List<List<object>> as follows:
            // [ [Row1/Col1 , Row1/Col2 ...], [Row2/Col1, Row2/Col2 ...], [Row3/Col1, Row3/Col2 ... ], ...]
            for(int i = 0; i < values.Count; ++i)
            {
                //Here is a list of object for each ROW
                for (int j = 0; j < values[i].Count; ++j) {
                    //Here is an object for each cell
                    object val = values[i][j];
                    string valStr = Convert.ToString(val);
                    csvLines += valStr;

                    if (j != headers.Count - 1) csvLines += ",";
                }
                //next line for next row
                csvLines += Environment.NewLine;
            }
            return csvLines;
        }

        public static bool GenerateCSVFileFromData(string path, List<string> headers, List<List<object>> values)
        {
            try
            {
                string csvLines = CSVHelper.GenerateCSVFromData(headers, values);
                using (var w = new StreamWriter(path))
                {
                    w.Write(csvLines);
                    w.Flush();
                }
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
