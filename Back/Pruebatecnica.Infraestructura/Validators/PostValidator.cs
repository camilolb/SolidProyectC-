using System;
using FluentValidation;
using PruebaTecnica.Core.DTOs;

namespace Pruebatecnica.Infraestructura.Validators
{
    public class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(5, 500);

        }
    }
}
