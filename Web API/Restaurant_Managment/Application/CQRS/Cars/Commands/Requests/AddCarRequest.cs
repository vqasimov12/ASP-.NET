using Application.CQRS.Cars.Commands.Responses;
using Common.GlobalResopnses.Generics;
using MediatR;

namespace Application.CQRS.Cars.Commands.Requests;

public record AddCarRequest:IRequest<ResponseModel<AddCarResponse>>
{
    public string Model { get; set; }
    public string Vendor { get; set; }
    public DateTime Year { get; set; }
    public decimal IntitialPrice { get; set; }
}
