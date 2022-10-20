using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Cinema>();
            CreateMap<Cinema, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Cinema>();
        }
    }
}
