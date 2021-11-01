using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Models.Factories
{
    public class GenreFactory
    {
        public static IGenre Create(string name){
            return new Genre(name);
        }
    }
}