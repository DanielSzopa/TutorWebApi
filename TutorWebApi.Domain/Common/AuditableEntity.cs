namespace TutorWebApi.Domain
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string CreateId { get; set; }
        public DateTime CreateDate { get; set; }
        public string? ModifyId { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? InactivateId { get; set; }
        public DateTime? InactivateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
