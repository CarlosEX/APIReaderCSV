using System.Linq;
using ApiCsvReaderRegex.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCsvReaderRegex.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        [HttpGet("/skip/{skip:int}/take/{take:int}")]
        public IActionResult GetMovies(
            int skip = 0, 
            int take = 10) {

            if(!IsTakeValidate(take))
                return BadRequest();
            
            var movies = MovieServiceCSV.GetMovies()
                        .Skip(skip)
                        .Take(take);

            return Ok(
                new {
                    Quantidade = movies.Count(),
                    IndiceSkip = skip,
                    ItensTake = take,
                    Movies = movies
                }
            );
        }
        
        [HttpGet("/text/{text}/skip/{skip:int}/take/{take:int}")]
        public IActionResult GetMovies(
            string text, 
            int skip = 0, 
            int take = 10) {

            if(!IsTakeValidate(take))
                return BadRequest();
            
            var movies = MovieServiceCSV.GetMovies()
                        .Skip(skip)
                        .Take(take)
                        .Where(x => x.Title.Contains(text));

            return Ok(
                new {
                    Quantidade = movies.Count(),
                    IndiceSkip = skip,
                    ItensTake = take,
                    Movies = movies
                }
            );
        }
        
        private bool IsTakeValidate(int value){
            return value > 0 || value <= 25 ? true : false;
        }
    }
}