namespace Assignment3.Entities;
using Assignment3.Core;

public class TaskRepository : ITaskRepository
{

    private readonly KanbanContext _context;

    public TaskRepository(KanbanContext context) 
    {
        _context = context;
    }

    public (Response Response, int TaskId) Create(TaskCreateDTO task)
    {
        throw new NotImplementedException();
    }

    public Response Delete(int taskId)
    {
        
        var task = _context.tasks.Include(t => t.Id).FirstOrDefault(t => t.Id == taskId);
        State state;
        Response response;

        if (taskId is 0)
        {
            response = Response.NotFound;
        } 
        else if(task.state == State.New)
        {
            _context.tasks.Remove(task);
            _context.SaveChanges();
            response = Response.Deleted;
        }
        else if(task.state == State.Active)
        {
            task.state = State.Removed;
        }
        else if(task.state == State.Resolved || task.state == State.Closed || task.state == State.Removed)
        {
            response = Response.Conflict;
        }

        response = Response.NotFound;
        return response;

    }

    public TaskDetailsDTO Read(int taskId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAll()
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByState(Core.State state)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<TaskDTO> ReadAllRemoved()
    {
        throw new NotImplementedException();
    }

    public Response Update(TaskUpdateDTO task)
    {
        throw new NotImplementedException();
    }
}
