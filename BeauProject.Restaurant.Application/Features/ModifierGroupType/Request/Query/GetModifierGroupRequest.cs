﻿using BeauProject.Restaurant.Application.DTOs.ModifierGroup;
using BeauProject.Shared.Patterns.ResultPattern;
using MediatR;

namespace BeauProject.Restaurant.Application.Features.ModifierGroupType.Request.Query
{
    public record GetModifierGroupRequest(long Id) : IRequest<Result<ModifierGroupDto>>
    {

    }
}
