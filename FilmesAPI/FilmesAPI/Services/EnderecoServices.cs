using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FluentResults;
using System;
using System.Linq;

namespace FilmesAPI.Services
{
    public class EnderecoServices
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public EnderecoServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(enderecoDto);
        }

        internal Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Endereço não encontrado!");

            
        }

        internal Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return Result.Ok();
            }
            return Result.Fail("Endereço não encontrado!");
        }

        internal Endereco RecuperaEnderecoPorID(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return endereco;
            }
            return null;
        }
    }
}
