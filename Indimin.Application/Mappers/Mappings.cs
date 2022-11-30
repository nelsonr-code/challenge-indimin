using AutoMapper;
using Indimin.Application.DTOs;
using Indimin.Application.Features.Citizens.Commands;
using Indimin.Application.Features.Citizens.Queries;
using Indimin.Application.Features.Tareas.Commands;
using Indimin.Domain.Entities;

namespace Indimin.Application.Mappers;

public class Mappings : Profile
{
    public Mappings()
    {
        #region Commands

        CreateMap<InsertCitizen, Citizen>();

        #endregion

        #region Queries

        CreateMap<InsertTarea, Tareas>();

        #endregion

        #region DTOs

        CreateMap<Citizen, CitizenDto>();
        CreateMap<Tareas, TareaDto>();

        #endregion
    }
}