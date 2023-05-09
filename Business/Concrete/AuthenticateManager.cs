using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
using Core.Utils.Results;
using DataAccess;
using DataAccess.Domain;
using Domain.IdentityModels;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete;

public class AuthenticateManager : IAuthenticateService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IConfiguration _configuration;
    private IValidator<LoginModel> _validator;

    public AuthenticateManager(IConfiguration configuration, RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager, IValidator<LoginModel> validator)
    {
        _configuration = configuration;
        _roleManager = roleManager;
        _userManager = userManager;
        _validator = validator;
    }

    public async Task<IDataResult<Token>> Login(LoginModel model)
    {
        var result = _validator.ValidateAsync(model);
        if (result.Result.IsValid==false)
        {
           return new ErrorDataResult<Token>(result.Result.ToString());
        }
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);
            var tokenModel = new Token()
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
            return new SuccessDataResult<Token>(tokenModel, "Giriş işlemi Başarılı");
        }

        return new ErrorDataResult<Token>("Giriş işlemi Başarısız");
    }

    public async Task<IResult> Register(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return new ErrorResult("User already exists!");
            string firstNameTrimmed = String.Concat(model.FirstName.Where(c => !Char.IsWhiteSpace(c)));
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.Lastname,
                UserName = firstNameTrimmed.ToLower()+model.Lastname
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new ErrorResult("User creation failed! Please check user details and try again.");

            return new SuccessResult("User Created");
        }

        public async Task<IResult> RegisterAdmin(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return new ErrorResult("User already exists!");

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.Lastname,
                UserName = model.FirstName + model.Lastname
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new ErrorResult("User creation failed! Please check user details and try again.");
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return new SuccessResult("User Created");
        }

        public async Task<IResult> AddRoleToUser(string email,string role)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
                await _userManager.AddToRoleAsync(user, role);
                return new SuccessResult("Rol Eklendi");

        }
        public async Task<IResult> ChangePassword(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, password);
            return new SuccessResult("Şifre değişimi başarılı");
        }

        public IDataResult<IQueryable<ApplicationUser>> GetUsers()
        {
            var users = _userManager.Users;
            return new SuccessDataResult<IQueryable<ApplicationUser>>(users);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
        
    }
