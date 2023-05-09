using Core.Utils.Results;

namespace Business.Abstract;

public interface IRoleService
{
    public Task<IResult> CreateRole(string roleName,string? description);
    public Task<IResult> DeleteRole(string role);
}