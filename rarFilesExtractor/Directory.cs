using System;
using System.IO;

namespace rarFilesExtractor

{
    public class Directory
    {
        public static FileInfo[] getFiles()
        {
            String directory = EnvironmentVariables.getEnvironmentVariable("working_directory");
            DirectoryInfo di = new DirectoryInfo(@directory);
            FileInfo[] zipFiles = di.GetFiles("*" + EnvironmentVariables.getEnvironmentVariable("files_name_containing_string") + "*.zip");
            // FileInfo[] rarFiles = di.GetFiles("*" + EnvironmentVariables.getEnvironmentVariable("files_name_containing_string") + "*.rar");

            /* foreach (FileInfo file in zipFiles)
                Console.WriteLine(file.Name); */

            return zipFiles;
        }
    }
}