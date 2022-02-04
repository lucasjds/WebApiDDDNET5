using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Domain.Repository;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Service.Services
{
  public class LoginService : ILoginService
  {
    private IUserRepository _repository;

    public SigningConfigurations _signingConfigurations;
    public TokenConfigurations _tokenConfigurations;
    public IConfiguration _configuration { get; }

    public LoginService(IConfiguration configuration, IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
    {
      _repository = repository;
      _signingConfigurations = signingConfigurations;
      _tokenConfigurations = tokenConfigurations;
      _configuration = configuration;
    }

    public async Task<object> FindByLogin(LoginDto user)
    {
      var baseUser = new UserEntity();

      if (user != null && !string.IsNullOrWhiteSpace(user.Email))
      {
        baseUser = await _repository.FindByLogin(user.Email);
        if(baseUser == null)
        {
          return new
          {
            authenticated = false,
            message = "Falha ao autenticar"
          };
        }
        else
        {
          var identity = new ClaimsIdentity(new GenericIdentity(baseUser.Email),
                                           new[]
                                           {
                                             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                             new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),

                                           });

          var createDate = DateTime.Now;
          var expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

          var handler = new JwtSecurityTokenHandler();
          string token = CreateToken(identity, createDate, expirationDate, handler);
          return SuccessObject(createDate, expirationDate, token, baseUser);
        }
      }
      return new
      {
        authenticated = false,
        message = "Falha ao autenticar"
      };
    }

    private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
    {
      return new
      {
        authenticated = true,
        created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
        expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
        accessToken = token,
        userName = user.Email,
        name = user.Nome,
        message = "Usuario logado com sucesso"
      };
    }

    private string CreateToken(ClaimsIdentity claimsIdentity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
      var securityToken = jwtSecurityTokenHandler.CreateToken(new SecurityTokenDescriptor 
      { 
        Issuer = _tokenConfigurations.Issuer,
        Audience = _tokenConfigurations.Audience,
        SigningCredentials = _signingConfigurations.SigningCredentials,
        Subject = claimsIdentity,
        NotBefore = createDate,
        Expires = expirationDate
      
      });

      var token = jwtSecurityTokenHandler.WriteToken(securityToken);
      return token;
    }

  }
}
