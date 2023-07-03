using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmeController : ControllerBase
{
    //private static List<Filme> filmes = new List<Filme>();
    //private static int id = 0;

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto) 
    {
        //filme.Id = id++;
        //filmes.Add(filme);

        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorID), new { id = filme }, filme);

    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 10) {
       
        //return filmes.Skip(skip).Take(take);
        return _context.Filmes.Skip(skip).Take(take);

    }
    [HttpGet("{id}")]
    public IActionResult? RecuperaFilmePorID(int id) 
    {
       //var filme = filmes.FirstOrDefault(filme => filme.Id == id);
       var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
