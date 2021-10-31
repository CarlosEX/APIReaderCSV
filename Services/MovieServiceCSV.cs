using System.Collections.Generic;
using System.IO;
using ApiCsvReaderRegex.Models;
using ApiCsvReaderRegex.Models.Factories;
using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Services {
    public class MovieServiceCSV {
        public static readonly string filePath = @"/home/carlosantonio/Documentos/dataset/movies.csv"; 
        
        public static IList<IMovie> GetMovies() {
            return GetMovieFileReadAllLines();
        }

        private static IList<IMovie> GetMovieFileReadAllLines() {
            
            try {
                
                string[] lines = File.ReadAllLines(filePath);
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
        private static IList<IGenre> GetListSplitGenre(string text){
            
            var parts = text.Split('|');
            var genres = new List<IGenre>();
            
            foreach(var part in parts){
                genres.Add(new Genre(part));
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