using System;
using System.IO;


namespace Document_Merger
{
    class Program
    {
        static void Main(string[] args)
        {
            string keepRunning = "yes";
            while(keepRunning == "yes" || keepRunning == "Yes")
            {
                Console.WriteLine("Document Merger\n\nEnter the name of the first text file");
                string file1 = Console.ReadLine();
                file1 = AddExtension(file1);
                file1 = VerifyFile(file1);
                Console.WriteLine("Enter the name of the second text file");
                string file2 = Console.ReadLine();
                file2 = AddExtension(file2);
                file2 = VerifyFile(file2);
                string newFile = CombineFileNames(file1, file2);
                CombineFiles(file1, file2, newFile);
                Console.WriteLine("Would you like to combine two more files?\n" + "Enter yes or no.");
                keepRunning = Console.ReadLine();
            }

        }

        static string AddExtension(string file)
        {
            string extension = Path.GetExtension(file);
            if(extension != ".txt")
            {
                file = file + ".txt";
    
            }
            return file;
        }

        static string VerifyFile(string file)
        {

            bool fileExists = File.Exists(file);
            while(fileExists == false)
            {
                Console.WriteLine("File does not exist. Enter new file name");
                file = Console.ReadLine();
                file = AddExtension(file);
                fileExists = File.Exists(file);
            }
                return file;
        }

        static string CombineFileNames(string _file1, string _file2)
        {
            _file1 = Path.ChangeExtension(_file1, null);
            _file2 = Path.ChangeExtension(_file2, null);
            string NewFile = _file1 + _file2 + ".txt";
            return NewFile;
        }

        static void CombineFiles(string _file1, string _file2, string NewFile)
        {
            string _file1contents = "";
            string _file2contents = "";

            try
            {
                StreamReader sr1 = new StreamReader(_file1);
                _file1contents = sr1.ReadToEnd();
                StreamReader sr2 = new StreamReader(_file2);
                _file2contents = sr2.ReadToEnd();
                string NewFileContents = _file1contents + _file2contents;
                int count = NewFileContents.Length;

                using(StreamWriter sw = new StreamWriter(NewFile))
                {
                    sw.WriteLine(NewFileContents);
                }

                Console.WriteLine("\n{0} was successfully saved. The document contains {1} characters.", NewFile, count);

            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
