using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using Application.Security;
using AutoMapper;
using Common.GlobalResopnses.Generics;
using Domain.Entites;
using FluentValidation;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class UpdateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCategoryRequest> validator, IUserContext userContext) : IRequestHandler<UpdateCategoryRequest, ResponseModel<UpdateCategoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateCategoryRequest> _validator = validator;
    private readonly IUserContext _userContext = userContext;

    public async Task<ResponseModel<UpdateCategoryResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        category.UpdatedBy = _userContext.MustGetUserId();

        await _unitOfWork.CategoryRepository.Update(category);

        var response = _mapper.Map<UpdateCategoryResponse>(category);

        return new ResponseModel<UpdateCategoryResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}
