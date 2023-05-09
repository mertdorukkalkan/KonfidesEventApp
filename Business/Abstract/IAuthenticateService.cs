using Core.Domain;
using Core.Utils.Results;
using DataAccess;
using Domain.IdentityModels;

namespace Business.Abstract;

public interface IAuthenticateService
{
    public  Task<IDataResult<Token>> Login(LoginModel model);
    public Task<IResult> Register(RegisterModel model);
    public Task<IResult> RegisterAdmin(RegisterModel model);
    public Task<IResult> ChangePassword(string email, string password);

    public IDataResult<IQueryable<ApplicationUser>> GetUsers();

    public Task<IResult> AddRoleToUser(string email, string role);
}