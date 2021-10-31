using System.Collections.Generic;
using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Models.Factories {
    public class MovieFactory {
        public static IMovie Create(int id, string title, IList<IGenre> genres){
            return new Movie(id, title, genres);
        }
    }
}