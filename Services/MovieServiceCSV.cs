using System;
using System.Collections.Generic;
using System.IO;
using ApiCsvReaderRegex.Models;
using ApiCsvReaderRegex.Models.Factories;
using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Services {
    public class MovieServiceCSV {
        
        public static IList<IMovie> GetMovieFileReadAllLines() {
            
            try {
                
                string[] lines = File.ReadAllLines(GetPathFileCsv());

                IList<IMovie> listMovie = new List<IMovie>();

                foreach (var line in lines) {
                    
                    var parts = line.Split(',');

                    listMovie.Add(
                        MovieFactory.Create(
                            id: IsValidateIdMovie(parts[0]),
                            title: parts[1],
                            genres: GetListSplitGenre(parts[2])
                        )
                    );
                }
                
                return listMovie;
            }
            catch (System.Exception){
                throw;
            }
        }
       
        public static IList<IMovie> GetMovieFileOpenReadStreamReader() {
            
            try {
                
                var listMovie = new List<IMovie>();
                string line;
                
                using(FileStream fs = File.OpenRead(GetPathFileCsv()))
                using(var reader = new StreamReader(fs))
                while((line = reader.ReadLine()) != null){
                    
                    var parts = line.Split(',');

                    listMovie.Add(
                        MovieFactory.Create(
                            id: IsValidateIdMovie(parts[0]),
                            title: parts[1],
                            genres: GetListSplitGenre(parts[2])
                        )
                    );
                }

                return listMovie;
            }
            catch (System.Exception){
                throw;
            }
        }

        private static string GetPathFileCsv(){
            var pathCurrent = Directory.GetCurrentDirectory();
            var fullPathFile = Path.Combine(pathCurrent,"Data/movies.csv");
            return fullPathFile;
        }

        private static IList<IGenre> GetListSplitGenre(string text){
            
            var parts = text.Split('|');
            var genres = new List<IGenre>();
            
            foreach(var part in parts){
                genres.Add(GenreFactory.Create(part));
            }

            return genres;
        }
        
        private static int IsValidateIdMovie(string value){
            int number;

            bool success = int.TryParse(value, out number);

            if(success)
                return int.Parse(value);
            
            return number;
        }
    }
}