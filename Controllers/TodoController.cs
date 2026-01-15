using dotnet_CRUD.Contexts;
using dotnet_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace dotnet_CRUD.Controllers;

public class TodoController : Controller
{
    private readonly TodosContext _context;

    public TodoController(TodosContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewData["Title"] = "ToDo List";
        var todos = _context.Todos.ToList();
        return View(todos);
    }
    public IActionResult Create()
    {
        ViewData["Title"] = "New Task";
        return View("Forms");
    }
    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        if (ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewData["Title"] = "New Task";
        return View("Forms", todo);
    }
    public IActionResult Edit(int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Edit Task";
        return View("Forms", todo);
    }
    [HttpPost]
    public IActionResult Edit (Todo todo)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Title"] = "Edit Task";
            return View("Forms", todo);
        }

        var todoDb = _context.Todos.Find(todo.Id);

        if (todoDb == null)
            return NotFound();

        todoDb.Title = todo.Title;
        todoDb.DeadLine = todo.DeadLine;
        todoDb.FinishedAt = todo.FinishedAt;

        _context.SaveChanges();
        return RedirectToAction("Index");
            
    }
    public IActionResult Delete (int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Delete Task";
        return View(todo);
    }
    [HttpPost]
    public IActionResult Delete (Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Finish (int id)
    {
        var todo = _context.Todos.Find(id);
        if(todo is null)
        {
            return NotFound();
        }
        //Lógica final inserida em Model - Todo
        todo.Finish();
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}