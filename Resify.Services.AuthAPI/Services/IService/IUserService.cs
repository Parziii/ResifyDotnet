using Resify.Services.AuthAPI.Models.Dto;

namespace Resify.Services.AuthAPI.Services.IService;

public interface IUserService
{
	Task<LoginResponseDto> ChangePassword(PasswordDto passwordObject, string mail);
	Task<LoginResponseDto> ChangePersonalData(PersonalDataDto personalDataDto);
	Task<UserFavDto> GetUserInfo(string mail);
}