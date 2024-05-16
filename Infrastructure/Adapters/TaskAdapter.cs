using Core.Models;
using Infrastructure.Interfaces;
namespace Infrastructure.Adapters;
public class TaskAdapter : ITaskPort
{
    private static List<TaskModel> tasks = new List<TaskModel>();
    public IEnumerable<TaskModel> GetAllTasks() => tasks;
    public void AddTask(TaskModel task) => tasks.Add(task);
    public void UpdateTask(TaskModel task)
    {
        if (tasks.Contains(task))
        {
            var updateTask = tasks.Where(x => x.Id == task.Id).FirstOrDefault();
            updateTask = task;
        }
    }
    public void DeleteTask(int taskId)
    {
        var task = tasks.Where(x => x.Id == taskId).FirstOrDefault();
        if (task is not null)
        {
            tasks.Remove(task);
        }
    }
}
