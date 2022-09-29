namespace Assignment3.Entities;


public class User
{
    public virtual int Id {get; set;}
    public virtual string Name {get; set; } = null!;

    public virtual string Email {get; set; } = null!;

    public virtual IList<Task> Tasks {get; set;}

    public User(string name, string email)
    {
        Tasks = new List<Task>();
        Name = name;
        Email = email;

    }
}
