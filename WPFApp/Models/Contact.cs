﻿using System;

namespace WPFApp.Models;

internal interface IContact
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }

}

internal class Contact : IContact
{
    public Guid Id { get ; set ; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get ; set ; } = null!;
    public string Email { get; set; } = null!; 
}

