﻿namespace TWJobs.Core.Models;

public class Job
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public decimal Salary { get; set; }
    public string? Requirements { get; set; }
}
