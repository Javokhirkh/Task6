using System.ComponentModel.DataAnnotations;

namespace ItransitionTask6.Data.Entities;

public class Message
{
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Body { get; set; }
    public DateTimeOffset SentTime { get; set; }
    [Required]
    public Guid SenderId { get; set; }
    [Required]
    public Guid ReceiverId { get; set; }
    
    public User Sender { get; set; }
    public User Receiver { get; set; }
}