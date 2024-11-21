using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{
    public static List<Movie> movies = new List<Movie>(); 

    [HttpPost]
    public IActionResult Create([FromBody] Movie movie)
    {
        movies.Add(movie);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAll([FromQuery] int page)
    {
        return movies.Skip(5*page).Take(5);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
 
}
