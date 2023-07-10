namespace Resify.Services.AuthAPI.Models.Dto
{
    public class RegistrationRequestDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
		public string RoleName { get; set; }
    }
}
