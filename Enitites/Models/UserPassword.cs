﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Enitites.Models;

public partial class UserPassword
{
    public int UserPasswordId { get; set; }

    public int UserId { get; set; }

    public int PasswordId { get; set; }

    public virtual PasswordTask Password { get; set; }

    public virtual User User { get; set; }
}