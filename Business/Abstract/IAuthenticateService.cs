using Core.Utils.Results;
using Domain.IdentityModels;

namespace Business.Abstract;

public interface IAuthenticateService
{
    public  Task<IDataResult<Token>> Login(LoginModel model);
    public Task<IResult> Register(RegisterModel model);
    public Task<IResult> RegisterAdmin(RegisterModel model);
}