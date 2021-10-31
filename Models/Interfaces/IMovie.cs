
using System.Collections.Generic;

namespace ApiCsvReaderRegex.Models.Interfaces
{
    public interface IMovie
    {
        int Id { get; }
        string Title { get; }
        IList<IGenre> Genres { get; }

        void SetChangeId(int value);
        void SetChangeTitle(string value);
        void AddGenre(IGenre genre);
        void RemoveGenre(IGenre genre);
        void InsertGenre(IGenre genre, int index);
    }
}