﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class PasswordTask
{
    public int PasswordTaskId { get; set; }

    public int TaskId { get; set; }

    public TimeSpan ReminderInterval { get; set; }

    public string DefaultMessage { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Task Task { get; set; }

    public virtual ICollection<UserPassword> UserPasswords { get; set; } = new List<UserPassword>();
}