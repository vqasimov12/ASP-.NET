using Application.CQRS.Cars.Queries.Requests;
using Application.CQRS.Cars.Queries.Responses;
using Application.Patterns;
using Common.Exceptions;
using Common.GlobalResopnses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Cars.Handlers.QueryHandlers;

public class GetCarByPriceTypeHandler(IUnitOfWork unitOfWork, ICarStrategy carStrategy) : IRequestHandler<GetCarByPriceTypeRequest, ResponseModel<GetCarByPriceTypeResponse>>
{
    public async Task<ResponseModel<GetCarByPriceTypeResponse>> Handle(GetCarByPriceTypeRequest request, CancellationToken cancellationToken)
    {
        var car = await unitOfWork.CarRepository.GetCarById(request.carId);

        if (car is null)
            throw new BadRequestException("Invalid car Id");

        return new ResponseModel<GetCarByPriceTypeResponse>
        {
            Data = new GetCarByPriceTypeResponse
            {
                Id = car.Id,
                Model = car.Model,
                Vendor = car.Vendor,
                Year = car.Year,
                TotalPrice = await carStrategy.Calculate(car.Id, request.priceType)
            },
            IsSuccess = true,
            Errors = []
        };
    }
}
