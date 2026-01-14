using dotnet_CRUD.Contexts;
using dotnet_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

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
}