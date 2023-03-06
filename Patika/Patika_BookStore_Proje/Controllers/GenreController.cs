using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.CreateGenre;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.DeleteGenre;
using Patika_BookStore_Proje.Applications.GenreOperations.Commands.UpdateGenre;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenreById;
using Patika_BookStore_Proje.Applications.GenreOperations.Queries.GetGenres;
using Patika_BookStore_Proje.DBOperations;

namespace Patika_BookStore_Proje.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);

            return Ok(query.Handle());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.GenreId = id;
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);
            
            return Ok(query.Handle());
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }
    }
}