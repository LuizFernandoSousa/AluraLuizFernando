using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class FilmeServices
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionarFilme(CreateFilmeDto filmedto)
        {
            Filme filme = _mapper.Map<Filme>(filmedto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto ;
            }
            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorID(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }
            return null;
        }

        public Result AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                _mapper.Map(filmeDto, filme);
                _context.SaveChanges();
                return Result.Ok();
            }           
            return Result.Fail("Filme não encontrado!");
            

        }

        public Result DeletaFilme(int id)
        {
            Filme filmeDto = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeDto != null)
            {
                _context.Remove(filmeDto);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Filme não encontrado!");

        }
    }
}
