var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// "DB" en memoria
var todos = new List<TodoItem>
{
    new(1, "Aprender C# básico", false),
    new(2, "Probar endpoints con Postman", true)
};

// GET /
app.MapGet("/", () => Results.Ok("API funcionando Prueba /todos"));

// GET /todos
app.MapGet("/todos", () => Results.Ok(todos));

// GET /todos/{id}
app.MapGet("/todos/{id:int}", (int id) =>
{
    var todo = todos.FirstOrDefault(t => t.Id == id);
    return todo is null ? Results.NotFound() : Results.Ok(todo);
});

// POST /todos
app.MapPost("/todos", (CreateTodoRequest req) =>
{
    if (string.IsNullOrWhiteSpace(req.Title) || req.Title.Trim().Length < 3)
        return Results.BadRequest(new { error = "Title debe tener al menos 3 caracteres." });

    var nextId = (todos.Count == 0) ? 1 : todos.Max(t => t.Id) + 1;
    var todo = new TodoItem(nextId, req.Title.Trim(), false);
    todos.Add(todo);

    return Results.Created($"/todos/{todo.Id}", todo);
});

// PUT /todos/{id}
app.MapPut("/todos/{id:int}", (int id, UpdateTodoRequest req) =>
{
    var index = todos.FindIndex(t => t.Id == id);
    if (index < 0) return Results.NotFound();

    if (string.IsNullOrWhiteSpace(req.Title) || req.Title.Trim().Length < 3)
        return Results.BadRequest(new { error = "Title debe tener al menos 3 caracteres." });

    var updated = todos[index] with { Title = req.Title.Trim(), IsDone = req.IsDone };
    todos[index] = updated;

    return Results.NoContent();
});

// DELETE /todos/{id}
app.MapDelete("/todos/{id:int}", (int id) =>
{
    var todo = todos.FirstOrDefault(t => t.Id == id);
    if (todo is null) return Results.NotFound();

    todos.Remove(todo);
    return Results.NoContent();
});

app.Run();

public record TodoItem(int Id, string Title, bool IsDone);
public record CreateTodoRequest(string Title);
public record UpdateTodoRequest(string Title, bool IsDone);