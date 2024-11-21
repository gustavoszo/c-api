using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{

    private MovieContext _movieContext;

    public MovieController(MovieContext movieContext)
    {
        _movieContext = movieContext;   
    }

    [HttpPost]
    public IActionResult Create([FromBody] Movie movie)
    {
        _movieContext.Movies.Add(movie);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAll([FromQuery] int page)
    {
        return _movieContext.Movies.Skip(5*page).Take(5);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }
 
}
