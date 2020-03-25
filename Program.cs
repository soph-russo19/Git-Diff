using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Git_Diff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());

            Console.WriteLine("The following doscuments are available for comparison: \n1 GitRepositories_1a \n2 GitRepositories_2a\n3 GitRepositories_2b \n4 GitRepositories_3a \n5 GitRepositories_3b");
            Console.WriteLine("Please select the first document you wish to compare: ");
            

            //User inputs the first file they wish to compare.
            string First_FilePath = Console.ReadLine();

            // The returned string is stored as a local variable within Main()
            string First_File = ReadFiles.readFiles(First_FilePath);
            StreamReader First_Reader = new StreamReader(First_FilePath);

            Console.WriteLine("Please select the second document you wish to compare: ");

            // The same thing is then repeated for the second file
            string Second_FilePath = Console.ReadLine();
            string Second_File = ReadFiles.readFiles(Second_FilePath);
            StreamReader Second_Reader = new StreamReader(Second_FilePath);

            // The bool from comparefiles method is returned and stored locally;
            bool Files_Same = Compare_Files(First_File, Second_File);

            // If the bool is true, then the files are the same 
            if (Files_Same == true)
            {
                Console.WriteLine(" The two files that you have selected are the same");
            }

            //Otherwise they are different
            else
            {
                Console.WriteLine("The compared that you have selected are not the same");
            }
        }

        // Method for comparing the two text files as arguments
        static bool Compare_Files(string First_File, string Second_File)
        {
            bool Files_Same;

            // if the arguments are the same, return outcome as true
            if(First_File == Second_File)
            {
                Files_Same = true;
            }

            // If not then return false
            else
            {
                Files_Same = false;
            }
            return Files_Same;
        }
    }

    // This class reads a singular file
    class ReadFiles
    {
        // The method of the class
        public static string readFiles(string File_Choice)
        {
            // Intialize a StreamReader object
            StreamReader Text_Object = new StreamReader(@"" + First_FilePath+ ".txt");

            //Creates a file path for StreamReader
            string File_Input = $@"";

            //Ensures the while loop runs until a correct file path is found
            bool File_Found = false;
            while (File_Found == false)
            {
                try
                {
                    Text_Object = new StreamReader(File_Input);

                    File_Found = true;
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine(" Invalid file selected, please try again:");

                    File_Choice = Console.ReadLine();
                    File_Input = $@"textFiles/{File_Choice}.txt";
                }
            }

            string textfile = Text_Object.ReadToEnd();

            return textfile;
        }
    }
}

