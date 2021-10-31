
using System.Collections.Generic;
using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Models {
    
    public class Movie : IMovie {
        public Movie(int id, string title, IList<IGenre> genres) {
            Id = id;
            Title = title;
            Genres = genres;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public IList<IGenre> Genres { get; private set; } = new List<IGenre>();

        public void SetChangeId(int value) {
            this.Id = value;
        }
        public void SetChangeTitle(string value) {
            this.Title = value;
        }
        public void AddGenre(IGenre genre) {
            this.Genres.Add(genre);
        }
        public void RemoveGenre(IGenre genre) {
            this.Genres.Remove(genre);
        }
        public void InsertGenre(IGenre genre, int index) {
            this.Genres.Insert(index, genre);
        }
    }
}