using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace FileFinder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path;
            string fileName;
            Console.WriteLine("Введите название файла:");
            fileName = Console.ReadLine();
            Console.WriteLine("Введите путь до файла или до преполагаемой директории:");
            path = Console.ReadLine();

            string[] Files = Directory.GetFiles(path, fileName, SearchOption.AllDirectories);
            foreach(var elem in Files)
            {
                Console.WriteLine(elem);
                using (FileStream fstream = new FileStream(elem, FileMode.Open))
                {
                    byte[] buffer = new byte[fstream.Length];
                    await fstream.ReadAsync(buffer, 0, buffer.Length);
                    string text = Encoding.Default.GetString(buffer);
                    Console.WriteLine($"{text}");
                }
            }

            foreach (var elem in Files)
            {
                Console.WriteLine(elem);
                using (FileStream sourceFile = new FileStream(elem, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = new FileStream("Compressed.zip", FileMode.Create))
                    {

                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            await sourceFile.CopyToAsync(compressionStream);
                            Console.WriteLine($"Сжатие файла {elem} завершено.");
                            Console.WriteLine($"Начальный обЪём: {sourceFile.Length}");
                            Console.WriteLine($"Объём сжатого файла: {targetStream.Length}");
                        }
                    }
                }
            }

        }
    }
}
