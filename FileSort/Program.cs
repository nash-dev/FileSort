using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace FileSort
{
    class Program
    {
        public static void Main(string[] args)
        {
           

            string originalFiles = ("\\Downloads\\UnSortedTest");

            string filesToSortByAlbumName = @"-";
            string[] fileList = System.IO.Directory.GetFiles(originalFiles, filesToSortByAlbumName, SearchOption.TopDirectoryOnly);

            string destinationPathArtistNamesFolder = "\\Downloads\\UnSortedTest\\Artist";
            {
                string[] input = {
                                 "NameOfSong 0",
                                 "Nameof Song - Artist 1",
                                 "Nameof Song - Artist - Album 2",                
                };
                string[] output = input.Select(x => new HyphenString(x)).OrderBy(x => x).Select(x => x.name).ToArray();
            }
        }
        public class HyphenString : IComparable<HyphenString>
        {
            public string name { get; set; }
            List<string> names { get; set; }

            public HyphenString(string name)
            {
                this.name = name;
                names = name.Split(new char[] { '-' }).ToList();
            }
            public int CompareTo(HyphenString other)
            {
                int results = 0;
                int minLength = Math.Min(names.Count, other.names.Count);

                for (int i = 0; i < minLength; i++)
                {
                    results = this.names[i].CompareTo(other.names[i]);
                  
                    if (results != 0) return results;
                }

                return names.Count.CompareTo(other.names.Count); ;
            }

        }

        /*
           string originalFiles = ("C:\\Users\\IGENGRAPHICS\\Downloads\\UnSortedTest");
           //Directory.GetFiles(originalFiles, "*.mp3").Select(fn => new FileInfo(fn)).
           //                OrderBy(f => f.Name);

           //int index = originalFiles.IndexOf("-");
           //string nameofsong = originalFiles.Split("-");
           //var hyphen = new char[] { '-' };


           string filesToSortByAlbumName = @"-";  // Only delete WAV files ending by "_DONE" in their filenames
           string[] fileList = System.IO.Directory.GetFiles(originalFiles, filesToSortByAlbumName, SearchOption.TopDirectoryOnly);

           string destinationPathArtistNamesFolder = "\\Downloads\\UnSortedTest\\Artist";

           foreach (string file in fileList)
           {

               string fileToMove = originalFiles + file;
               string moveTo = destinationPathArtistNamesFolder + file;
               //moving file
               File.Move(fileToMove, moveTo);
           }


           string patternArtist1stHyphen = @"(?<= - ).* ";
           Regex rgArt = new Regex(patternArtist1stHyphen);

           var files = Directory.GetFiles(originalFiles, "*.mp3")
                                    .Where(path => rgArt.IsMatch(path))
                                    .ToList();


           var orderedFiles = originalFiles.Select(filename =>
           {
               // TODO: decide what to do if filename incorrect format
               string[] splitFileName = originalFiles.Split(@"(?<= - ).* ");

               int filecategory;
               switch (splitFileName[2])
               {
                   case "NameofSong":
                       filecategory = 0;
                       break;
                   case "Artist":
                       filecategory = 1;
                       break;
                   case "Album":
                       filecategory = 2;
                       break;
                   default:
                       filecategory = 3;
                       break;
               }

               return new
               {
                   FileYear = Int32.Parse(splitFileName[0]),
                   FilePeriod = filecategory,
                   OriginalFileName = filename,
               };
           })

           // sort:
           .OrderBy(splitFile => splitFile.FileYear)
           .ThenBy(splitFile => splitFile.FilePeriod)

           // back to original filename
           .Select(splitFile => splitFile.OriginalFileName);

           Console.ReadLine();
           Console.WriteLine("Hello World!");
           */



    }
}
