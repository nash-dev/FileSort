using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

namespace FileSort
{
    class Program
    {
        public static void Main(string[] args)
        {

          //  List<string> NameOfSongList = new List<string>();
          //  List<string> AlbumList = new List<string>();
          //  List<string> ArtistList = new List<string>();
           
            string folder = ("C:\\Users\\IGENGRAPHICS\\Downloads\\UnSortedMusicFolder");
            var files = Directory.GetFiles(folder).Min(filename => filename);

            char[] separators = new char[] { '-' };

           // string[] splity = files.Split(new char[] { '.','-', '\n'},
             //                StringSplitOptions.RemoveEmptyEntries);
            string[] split = files.Split(new Char[] { '-', '-', '\n' },
                             StringSplitOptions.RemoveEmptyEntries);

            string[] result = Regex.Split(files, ".-");


            string filesToSortByAlbumName = @"-";

            // string[] fileList = System.IO.Directory.GetFiles(folder, filesToSortByAlbumName);
      
           var allfiles =  Directory.GetFiles(folder, "*.mp3").Select(fn => new FileInfo(fn)).
                 OrderBy(f => f.Name);


            foreach (var f in allfiles)
            {
                string[] splity = f.FullName.Split(new char[] { '.', '-', '\n' },
                     StringSplitOptions.RemoveEmptyEntries);

                var NameOfSongList = splity[0];
                Console.WriteLine(NameOfSongList);

                var Artist = splity[1];
                Console.WriteLine(Artist);


                var Album = splity[2];
                Console.WriteLine(Album);



                Console.WriteLine(splity);


                //Console.WriteLine($"Substring: {f}");
            }
            /*
            foreach(var f in fileList)
            {
        
            }

            foreach (var elem in ((IEnumerable)fileList[1]).Cast<>())
            {
                var id = elem.Id;
                var name = elem.Names;
            }


              
            

            foreach (var file in files)
            {

                string[] split = files.Split(new Char[] { '-', '-', '\n' },
                                 StringSplitOptions.RemoveEmptyEntries);
                

            }


                    foreach (var file in files)
            {
                char[] separators = new char[] { '-' };
                string[] subs = files.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (var sub in subs)
                {
                    Console.WriteLine($"Substring: {sub}");
                }
                Console.WriteLine(file);
            }


            foreach (var elem in ((IEnumerable)classArray[1]).Cast<ExcelSDRAddIn.UserControlSDR.Classification>())
            {
                var id = elem.Id;
                var name = elem.Names;
            }
            // string s = "You win some. You lose some.";


            string[] fileList = System.IO.Directory.GetFiles(folder);

            /*


            string path1 = @"c:\temp\MyTest.txt";
            string path2 = @"c:\temp\MyTest";
            string path3 = @"temp";

            if (Path.HasExtension(path1))
            {
                Console.WriteLine("{0} has an extension.", path1);
            }

            if (!Path.HasExtension(path2))
            {
                Console.WriteLine("{0} has no extension.", path2);
            }

            if (!Path.IsPathRooted(path3))
            {
                Console.WriteLine("The string {0} contains no root information.", path3);
            }

            Console.WriteLine("The full path of {0} is {1}.", path3, Path.GetFullPath(path3));
            Console.WriteLine("{0} is the location for temporary files.", Path.GetTempPath());
            Console.WriteLine("{0} is a file available for use.", Path.GetTempFileName());






            // taking full path of a file
            string strPath = "C:// myfiles//ref//file1.txt";

            // initialize the value of filename
            string filename = null;

            // using the method
            filename = Path.GetFileNameWithoutExtension(strPath);
            Console.WriteLine("Filename = " + filename);

            Console.ReadLine();














            string originalFiles = ("\\Downloads\\UnSortedTest");

            string filesToSortByAlbumName = @"-";

            List<string> names { get; set; }

            string[] fileList = System.IO.Directory.GetFiles(originalFiles, filesToSortByAlbumName, SearchOption.TopDirectoryOnly);

            string[] files = Directory.GetFiles(originalFiles).OrderBy(f => int.Parse(Path.GetFileNameWithoutExtension(f))).ToArray();


            string destinationPathArtistNamesFolder = "\\Downloads\\UnSortedTest\\Artist";


            DirectoryInfo di = Directory.CreateDirectory(destinationPathArtistNamesFolder);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(destinationPathArtistNamesFolder));

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
            /*

            */

        }
    }
}
