using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieController : ControllerBase
{

    private MovieContext _movieContext;
    private IMapper _iMapper;

    public MovieController(MovieContext movieContext, IMapper iMapper)
    {
        _movieContext = movieContext;   
        _iMapper = iMapper;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateMovieDto createMovieDto)
    {
        Movie movie = _iMapper.Map<Movie>(createMovieDto);
        _movieContext.Movies.Add(movie);
        _movieContext.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<ResponseMovieDto> GetAll([FromQuery] int page)
    {
        return _iMapper.Map<List<ResponseMovieDto>>(_movieContext.Movies.Skip(5*page).Take(5));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        return Ok(_iMapper.Map<ResponseMovieDto>(movie));
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();
        _iMapper.Map(updateMovieDto, movie);
        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PartialUpdate(int id, [FromBody] JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();

        // O ModelState é uma propriedade no ASP.Net Core usada para rastrear o estado de validação dos dados enviados em uma requisição HTTP.
        // O ASP.Net Core usa o ModelState para verificar se os dados enviados estão corretos de acordo com as validações definidas no modelo.
        patch.ApplyTo(movie, ModelState);

        if (!TryValidateModel(movie))
        {
            return BadRequest(ModelState);
        }

        _movieContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _movieContext.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound();

        _movieContext.Movies.Remove(movie);

        _movieContext.SaveChanges();
        return NoContent();
    }

}
