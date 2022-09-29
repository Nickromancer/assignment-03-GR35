namespace Assignment3.Entities;
using Assignment3.Core;

public class UserRepository : IUserRepository
{
    private readonly KanbanContext _context;

    public UserRepository(KanbanContext context) 
    {
        _context = context;
    }
    
    public (Response Response, int UserId) Create(UserCreateDTO user)
    {
        var newUser = _context.users.FirstOrDefault(c => c.Name == user.Name && c.Email == user.Email);
        Response response;

        if (newUser is null) 
        {
            newUser = new User(user.Name, user.Email);
            _context.users.Add(newUser);
            _context.SaveChanges();

            response = Response.Created;
            
        } 
        else 
        {
            response = Response.Conflict;
        }

        var userCreated = new UserDTO(newUser.Id, newUser.Name, newUser.Email);
        var userId = userCreated.Id;

        return (response, userId);
    }

    public Response Delete(int userId, bool force = false)
    {
        var user = _context.users.Include(u => u.Id).FirstOrDefault(c => c.Id == userId);
        Response response;

        if (userId is 0)
        {
            response = Response.NotFound;
        } 
        //else if (userId)
        //{
        //    response = Response.Conflict;
        //}
        else
        {
            _context.users.Remove(user);
            _context.SaveChanges();
            response = Response.Deleted;
        }

        return response;
    }

    public UserDTO Read(int userId)
    {
        var user = from u in _context.users
                     where u.Id == userId
                     select new UserDTO(u.Id, u.Name, u.Email);

        
        return user.FirstOrDefault();
    }

    public IReadOnlyCollection<UserDTO> ReadAll()
    {
        var users = from u in _context.users
                     orderby u.Id
                     select new UserDTO(u.Id, u.Name, u.Email);

        return users.ToArray();
    }

    public Response Update(UserUpdateDTO user)
    {
        var userUpdate = _context.users.Find(user.Id);
        Response response;
        
        if (user is null)
        {
            response = Response.NotFound;
        }
        else
        {
            userUpdate.Name = user.Name;
            userUpdate.Email = user.Email;            
            response = Response.Updated;
        }


            return response;

    // public record UserUpdateDTO(int Id, [StringLength(100)]string Name, [EmailAddress, StringLength(100)]string Email);

    }
}
