using Application.CQRS.Cars.Queries.Responses;
using Common.GlobalResopnses.Generics;
using MediatR;

namespace Application.CQRS.Cars.Queries.Requests;

public record GetByIdRequest:IRequest<ResponseModel<GetByIdResponse>>
{
    public int Id { get; set; }
}
