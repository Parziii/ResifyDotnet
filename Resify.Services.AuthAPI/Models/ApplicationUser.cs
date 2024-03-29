﻿using Microsoft.AspNetCore.Identity;

namespace Resify.Services.AuthAPI.Models;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public bool BusinessAccount { get; set; }
}