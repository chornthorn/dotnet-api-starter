using DotNetApp.Simples.Dto;
using DotNetApp.Simples.Entities;

namespace DotNetApp.Simples.Mapper;

public static class SimpleMapper
{
    public static Simple ToEntity(this SimpleDto simpleDto)
    {
        return new Simple
        {
            Name = simpleDto.Name,
        };
    }

    public static SimpleDto ToDto(this Simple simple)
    {
        return new SimpleDto
        {
            Name = simple.Name,
        };
    }

    public static CreateSimpleDto ToCreateDto(this Simple simple)
    {
        return new CreateSimpleDto
        {
            Name = simple.Name,
        };
    }

    public static UpdateSimpleDto ToUpdateDto(this Simple simple)
    {
        return new UpdateSimpleDto
        {
            Name = simple.Name,
        };
    }
}