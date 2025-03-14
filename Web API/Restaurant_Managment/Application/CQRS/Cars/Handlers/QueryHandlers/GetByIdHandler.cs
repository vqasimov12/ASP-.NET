using Application.CQRS.Cars.Queries.Requests;
using Application.CQRS.Cars.Queries.Responses;
using Common.Exceptions;
using Common.GlobalResopnses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Cars.Handlers.QueryHandlers;

public class GetByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdRequest, ResponseModel<GetByIdResponse>>
{
    public async Task<ResponseModel<GetByIdResponse>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var car =await unitOfWork.CarRepository.GetCarById(request.Id);

        if (car == null)
            throw new BadRequestException("invalid Car Id");
        return new ResponseModel<GetByIdResponse>
        {
            Data = new GetByIdResponse
            {
                Id = car.Id,
                Model = car.Model,
                Vendor = car.Vendor,
                InitialPrice = car.IntitialPrice,
                Year = car.Year
            },
            IsSuccess = true,
            Errors = []
        };

    }
}
