﻿using System.ComponentModel.DataAnnotations;

namespace MVCVoertuig.ViewModels;

public class LoginViewModel
{
    public int Id { get; set; }
    [EmailAddress] 
    public string Email { get; set; }
    [DataType(DataType.Password)] 
    public string Password { get; set; }
}