namespace Assignment3.Entities;

public class Tag
{
    public virtual int Id {get; set;}       
    [Required]
    public virtual string? Name {get; set;}
    public virtual ICollection<Task> tasks { get; set; } = new List<Task>();

}
