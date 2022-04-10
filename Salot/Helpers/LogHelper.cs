using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salot.Helpers
{
    public class LogHelper : IHelperBase
    {
        public static void WriteToErrorLog(string errorMessage, string folderLocation, string fileName)
        {
            try
            {
                string filePath = string.Format(folderLocation, fileName);
                if (!Directory.Exists(folderLocation))
                    Directory.CreateDirectory(folderLocation);

                StreamWriter textWriter = new StreamWriter(filePath, true, Encoding.UTF8);
                textWriter.WriteLine(errorMessage);
                textWriter.Flush();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
