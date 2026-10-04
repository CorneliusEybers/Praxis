namespace Praxis.Domain.Common;

public abstract class EntityBase
{
    public int Id { get; protected set; }

    public string CreatedBy { get; protected set; } = string.Empty;

    public DateTime CreatedDateTime { get; protected set; }

    public string? UpdatedBy { get; protected set; }

    public DateTime? UpdatedDateTime { get; protected set; }

    protected EntityBase()
    {
    }

    protected EntityBase(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedDateTime = DateTime.UtcNow;
    }

    public void MarkAsUpdated(string updatedBy)
    {
        UpdatedBy = updatedBy;
        UpdatedDateTime = DateTime.UtcNow;
    }
}