using Carter;
using CleanArchitechture.Application.UseCases.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitechture.Api.Modules
{
    public class TestModule : CarterModule
    {
        private readonly IMediator _mediator;
        public TestModule(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/hello", () => 
            {
                return Results.Ok();
            });

            app.MapPost("/hello", async ([FromBody] AddUserCommand request) =>
            {
                try
                {
                    return Results.Ok(await _mediator.Send(request));
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            });
        }
    }
}
