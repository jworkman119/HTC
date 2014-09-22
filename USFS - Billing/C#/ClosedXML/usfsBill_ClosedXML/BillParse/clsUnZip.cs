using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace BillParse
{
    class clsUnZip
    {
        public string[] UnzipFiles(string strPath, string[] Files)
        {
            int Unzipped=0;
            
            for (int j = 0; j < Files.Count(); j++)
            {
                FileStream fs = File.OpenRead(Files[j].ToString());
                ZipFile zf = new ZipFile(fs);
                zf.Password = "Max800";
                string FileName = UnzipFile(ref zf, strPath);

                if (FileName != "")
                {
                    fs.Close();

                    //   *****File.Delete(Files[j]);
                    // Returning the name of the new file, will be used for naming spreadsheets
                    Files[j] = strPath + "\\" + FileName;
                }
            }

            Files = reOrder_OnSize(strPath, Files);
            return Files;
        }

        private string UnzipFile(ref ZipFile Zip, string strDirectory)
        {
            string FileName="";

            foreach (ZipEntry zipEntry in Zip)
            {
                String entryFileName = zipEntry.Name;
                byte[] buffer = new byte[4096];     // 4K is optimum
                Stream zipStream = Zip.GetInputStream(zipEntry);

                // Manipulate the output filename here as desired.
                String fullZipToPath = Path.Combine(strDirectory, entryFileName);
                //string directoryName = Path.GetDirectoryName(fullZipToPath);
                FileName = RenameFile(fullZipToPath);
    
                // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                // of the file, but does not waste memory.
                // The "using" will close the stream even if an exception occurs.
                using (FileStream objWriter = File.Create(FileName))
                {
                    StreamUtils.Copy(zipStream, objWriter, buffer);
                    FileName = returnFileName(FileName);
                    
                }
            }
            
            Zip=null;
            
            return FileName;
        }

        public string RenameFile(string strFile)
        {
            string strNewFile = returnFileName(strFile);
            //find "FY"
            string strName = strNewFile.Substring(strNewFile.IndexOf("FY") - 9, 15);
            strName = strName.Replace("CoreSense_Monthly Billing Report", "");
            // Not sure if the previous line's is always going to be in the string.
            strName = strName.Replace("Core_SenseMonthly", "");
            strName = strName.Replace("Billing", "");
            strName = strName.Replace("Report", "");
            strName = strName.Replace("Monthly", "");
            strName = strName.Trim();

            strFile = strFile.Replace(strNewFile, strName);
            return strFile;
        }

        private string returnFileName(string strFilePath)
        {
            int Position = strFilePath.LastIndexOf("\\") + 1;
            string strFile = strFilePath.Substring(Position, strFilePath.Length - Position);

            return strFile;
        }

        private string[] reOrder_OnSize(string Path, string[] Files)
        {
            var Sort = from FileName in Files orderby new FileInfo(FileName).Length descending select FileName;

            int j = 0;
            foreach (string File in Sort)
            {
                Files[j] = File.Replace(Path + "\\","");
                j++;
            }
            return Files;
        }


    
    }
}

