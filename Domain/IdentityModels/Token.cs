using System.IdentityModel.Tokens.Jwt;

namespace Domain.IdentityModels;

public class Token
{
    public string token { get; set; }

    public DateTime Expiration { get; set; }
}