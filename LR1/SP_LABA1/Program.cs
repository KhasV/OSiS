using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace SP_LABA1
{
    class Program
    {
        static string[] SearchDirectory(string path)
        {
            string[] resultSearch = Directory.GetDirectories(path);
            return resultSearch;
        }

        static string[] SearchFiles(string path, string pattern)
        {
            string[] resultSearch = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            return resultSearch;
        }

        static void WriteResult(string resultFile, List<string> all_files)
        {
            List<string> resultText = new List<string>();
            foreach (string file in all_files)
            {
                resultText.AddRange(File.ReadAllLines(file));
                //resultText.Add(file + Environment.NewLine);
            }

            File.WriteAllLines(resultFile, resultText);   
        }

        static List<string> FoundFiles(string[] res, string path_for_search)
        {
            string print_res = "Найденные файлы  на диске" + path_for_search + ":\n";
            List<string> all_files = new List<string>();
            foreach (string folder in res)
            {
                try
                {
                    string[] files = SearchFiles(folder, "*lol*" + "*.txt"); //Выбор имени файла для поиска
                    foreach (string file in files)
                    {
                        print_res += file + "\n";
                        all_files.Add(file);
                    }
                }
                catch
                {

                    Console.WriteLine("Access is denied:\n" + folder);
                }
            }
            Console.WriteLine(print_res);
            Console.WriteLine("======================================================================");
            return all_files;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("D:\\ drive search");
            string path_for_search = "C:/";
            string resultFile = "C:\\Users\\varva\\Desctop\\DISC\\OSiS\\RESULT.txt";
            string[] res = SearchDirectory(path_for_search);
            List<string> all_files = FoundFiles(res, path_for_search);
            Console.WriteLine("\nC:\\ drive search");
            path_for_search = "C:/";
            res = SearchDirectory(path_for_search);
            List<string> all_files_c = FoundFiles(res, path_for_search);
            all_files.AddRange(all_files_c);
            WriteResult(resultFile, all_files);

        }
    }
}

