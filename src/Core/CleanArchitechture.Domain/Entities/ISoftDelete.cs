namespace CleanArchitechture.Domain.Entities
{
    public interface ISoftDelete
    {
       DateTime DeletedTime { get; set; }
       bool IsDeleted { get; set; }
    }
}
