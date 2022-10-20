using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Cinema;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap<CreateCinemaDto, Filme>();
            CreateMap<Filme, ReadCinemaDto>();
            CreateMap<UpdateCinemaDto,Filme>();
        }
    }
}
