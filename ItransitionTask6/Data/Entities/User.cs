using System.ComponentModel.DataAnnotations;

namespace ItransitionTask6.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    
    public ICollection<Message> SentMessages { get; set; }
    public ICollection<Message> ReceivedMessages { get; set; }
}