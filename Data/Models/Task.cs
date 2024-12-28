﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public TimeSpan? ScheduleInterval { get; set; }

    public virtual ICollection<PasswordTask> PasswordTasks { get; set; } = new List<PasswordTask>();

    public virtual ICollection<StockDatum> StockData { get; set; } = new List<StockDatum>();
}