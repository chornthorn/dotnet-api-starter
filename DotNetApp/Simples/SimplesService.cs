using DotNetApp.Core;
using DotNetApp.Core.attribute;
using DotNetApp.Simples.Dto;
using DotNetApp.Simples.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApp.Simples;

[Injectable]
public class SimplesService(SimplesRepository simplesRepository)
{
    public async Task<ActionResult<Response<List<SimpleDto>>>> FindAllAsync()
    {
        try
        {
            var simples = await simplesRepository.FindAllAsync();
            var simpleDto = simples.Select(simple => simple.ToDto());

            return new Response<List<SimpleDto>>
            {
                Data = simpleDto.ToList()
            };
        }
        catch (Exception e)
        {
            return new Response<List<SimpleDto>> { Message = e.Message };
        }
    }

    public async Task<ActionResult<Response<SimpleDto>>> FindByIdAsync(int id)
    {
        try
        {
            var simple = await simplesRepository.FindByIdAsync(id);
            return new Response<SimpleDto>
            {
                Data = simple.ToDto()
            };
        }
        catch (Exception e)
        {
            return new Response<SimpleDto> { Message = e.Message };
        }
    }

    public async Task<ActionResult<Response<SimpleDto>>> CreateAsync(CreateSimpleDto dto)
    {
        try
        {
            var createdSimple = await simplesRepository.CreateAsync(new()
            {
                Name = dto.Name
            });

            return new Response<SimpleDto>
            {
                Data = createdSimple.ToDto()
            };
        }
        catch (Exception e)
        {
            return new Response<SimpleDto> { Message = e.Message };
        }
    }

    public async Task<ActionResult<Response<SimpleDto>>> UpdateAsync(int id, UpdateSimpleDto dto)
    {
        try
        {
            var updatedSimple = await simplesRepository.UpdateAsync(id, new()
            {
                Name = dto.Name
            });

            return new Response<SimpleDto>
            {
                Data = updatedSimple.ToDto()
            };
        }
        catch (Exception e)
        {
            return new Response<SimpleDto> { Message = e.Message };
        }
    }

    public async Task<ActionResult<Response<SimpleDto>>> DeleteAsync(int id)
    {
        try
        {
            var deletedSimple = await simplesRepository.DeleteAsync(id);
            return new Response<SimpleDto>
            {
                Data = deletedSimple.ToDto()
            };
        }
        catch (Exception e)
        {
            return new Response<SimpleDto> { Message = e.Message };
        }
    }
}