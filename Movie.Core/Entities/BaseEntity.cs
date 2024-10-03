using System;

namespace Movie.Core;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
}