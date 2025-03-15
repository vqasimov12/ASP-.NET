using Application.Services;
using Common.GlobalResopnses.Generics;
using Domain.Entites;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.CQRS.Users.Handlers;

public class RefreshToken
{
    public class RefreshTokenRequest : IRequest<ResponseModel<string>>
    {
        public string Token { get; set; }
    }


    public class Handler(IUnitOfWork unitOfWork, IConfiguration configuration) : IRequestHandler<RefreshTokenRequest, ResponseModel<string>>
    {

        public async Task<ResponseModel<string>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await unitOfWork.RefreshTokenRepository.GetStoredRefreshToken(request.Token);

            if (refreshToken.ExpirationDate < DateTime.Now || refreshToken == null)
                throw new InvalidOperationException();

            var user = await unitOfWork.UserRepository.GetByIdAsync(refreshToken.UserId);

            List<Claim> authClaims = [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.Phone),
                new Claim(ClaimTypes.Role,user.UserRole.ToString())
             ];

            JwtSecurityToken jwtToken = TokenService.CreateToken(authClaims, configuration);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return new ResponseModel<string>
            {
                Data = tokenString,
                IsSuccess = true,
                Errors = []
            };
        }
    }
}