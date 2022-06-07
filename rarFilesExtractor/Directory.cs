using System;
using System.IO;
using System.Windows.Forms;

namespace rarFilesExtractor

{
    public class Directory
    {
        public static FileInfo[] getFiles()
        {
            try
            {
                String directory = EnvironmentVariables.getEnvironmentVariable("working_directory");
                DirectoryInfo di = new DirectoryInfo(@directory);
                FileInfo[] zipFiles = di.GetFiles("*" + EnvironmentVariables.getEnvironmentVariable("files_name_containing_string") + "*.zip");
                return zipFiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}