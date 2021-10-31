
using ApiCsvReaderRegex.Models.Interfaces;

namespace ApiCsvReaderRegex.Models{

    public class Genre : IGenre {
        public Genre(string name){
            Name = name;
        }
        public string Name { get; private set; }

        public void SetChangeName(string value){
            this.Name = value;
        }
    }
}