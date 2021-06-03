using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Services
{
    public class ReporterService : IReportService
    {
        private readonly IBookRepository _bookRepository;

        public ReporterService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task ReportActiveAndInactiveBooks()
        {
            IEnumerable<Book> books = await _bookRepository.GetAll();

            //Here we create Books Linq Query group by "State" //Using IGrouping Interface
            IEnumerable<IGrouping<string, Book>> groupQuery =
                from bks in books
                group bks by bks.State;

            //Here we generate file with report
            //With "@" we escape all slashes \
            string path = @"C:\Users\DANIEL\source\repos\NexusLibrary.API\Reports\";
            string file = $"Report_{DateTime.Now.ToString()}.txt";

            //We clean name file
            file = file.Replace("/", "-").Replace(":", "").Replace("p. m.", "").Replace("a. m.", "");
            path += file;

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                //With "true" the data is not override
                StreamWriter writerFile = new StreamWriter(path, true);

                writerFile.WriteLine($"REPORT STATE BOOKS {DateTime.Now.ToString()}");
                foreach (IGrouping<string, Book> stateGroup in groupQuery)
                {
                    writerFile.WriteLine("===========================================");
                    writerFile.WriteLine($"Books in State = '{stateGroup.Key.ToString()}'");
                    writerFile.WriteLine("===========================================");

                    foreach (Book bk in stateGroup)
                    {
                        writerFile.WriteLine($"{bk.Title} - {bk.Gender}");
                    }
                }
                writerFile.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
