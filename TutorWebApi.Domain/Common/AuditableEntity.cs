namespace TutorWebApi.Domain.Common
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public int? CreateById { get; set; }
        public DateTime CreateDate { get; set; }
        public int? ModifyById { get; set; }
        public DateTime? ModifyDate { get; set; }
        public bool IsActive { get; set; }
    }
}
