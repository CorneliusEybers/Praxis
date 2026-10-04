using Praxis.Domain.Common;

namespace Praxis.Domain.Entities;

public class AttendanceStatus : EntityBase
{
    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    protected AttendanceStatus()
    {
    }

    public AttendanceStatus(string code,
                            string name,
                            string? description,
                            string createdBy) : base(createdBy)
    {
        Code = code;
        Name = name;
        Description = description;
    }
}