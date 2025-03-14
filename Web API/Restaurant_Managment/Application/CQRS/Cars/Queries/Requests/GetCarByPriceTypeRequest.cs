using Application.CQRS.Cars.Queries.Responses;
using Common.GlobalResopnses.Generics;
using Domain.Enums;
using MediatR;

namespace Application.CQRS.Cars.Queries.Requests;

public record GetCarByPriceTypeRequest:IRequest<ResponseModel<GetCarByPriceTypeResponse>>
{
    public int carId {  get; set; }
    public PriceType priceType { get; set; }
}
