using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static List<TaskModel> tasks = new List<TaskModel>();

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskModel task)
    {
        task.Id = tasks.Count + 1;
        tasks.Add(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] TaskModel updatedTask)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.Title = updatedTask.Title;
        // Update other properties as needed

        return Ok(task);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        tasks.Remove(task);
        return NoContent();
    }
}

