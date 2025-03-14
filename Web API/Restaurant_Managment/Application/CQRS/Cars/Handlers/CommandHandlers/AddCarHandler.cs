using Application.CQRS.Cars.Commands.Requests;
using Application.CQRS.Cars.Commands.Responses;
using Common.GlobalResopnses.Generics;
using Domain.Entites;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Cars.Handlers.CommandHandlers;

public class AddCarHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCarRequest, ResponseModel<AddCarResponse>>
{
    public async Task<ResponseModel<AddCarResponse>> Handle(AddCarRequest request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            IntitialPrice = request.IntitialPrice,
            Model = request.Model,
            Vendor = request.Vendor,
            Year = request.Year,
        };

        await unitOfWork.CarRepository.AddCar(car);

        return new ResponseModel<AddCarResponse>
        {
            Data = new AddCarResponse
            {
                IntitialPrice = car.IntitialPrice,
                Model = car.Model,
                Vendor = car.Vendor,
                Year = car.Year,
            },
            IsSuccess = true,
            Errors = []
        };
    }
}
