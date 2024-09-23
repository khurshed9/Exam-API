using examAPI.Infrastructure.Services.CategoryService;
using examAPI.Infrastructure.Services.CategoryService.CategoryQueriesService;
using examAPI.Infrastructure.Services.CommentService;
using examAPI.Infrastructure.Services.CommentService.CommentQueriesService;
using examAPI.Infrastructure.Services.TaskAttachment;
using examAPI.Infrastructure.Services.TaskAttachment.TaskAttachmentQueriesService;
using examAPI.Infrastructure.Services.TaskHistory;
using examAPI.Infrastructure.Services.TaskHistory.TaskHistoryQueriesService;
using examAPI.Infrastructure.Services.TaskService;
using examAPI.Infrastructure.Services.TaskService.TaskQueriesService;
using examAPI.Infrastructure.Services.UserService;
using examAPI.Infrastructure.Services.UserService.UserQueriesService;
using examAPI.Models.Category;
using examAPI.Models.Comment;
using examAPI.Models.TaskAttachments;
using examAPI.Models.TaskHistory;
using examAPI.Models.User;
using Task = examAPI.Models.Task.Task;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5134/");

builder.WebHost.ConfigureKestrel(options => { options.AllowSynchronousIO = true; });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//////////////////////////////////////////////User//////////////////////////////////////////////////

UserService userService = new UserService();

app.MapGet("/api/users", async () =>
{
    return await userService.GetUsers();
});

app.MapGet("/api/users/{userName}", async (string userName) =>
{
    return await userService.GetUserByUserName(userName);
});

app.MapPost("/api/users", (User user) =>
{
    return userService.CreateUser(user);
});

app.MapPut("/api/users", (User user) =>
{
    return userService.UpdateUser(user);
});

app.MapDelete("/api/users/{userName}", (string userName) =>
{
    return userService.DeleteUser(userName);
});

///////////////////////////////////////////////Category////////////////////////////////////////////////////////////////////


CategoryService categoryService = new CategoryService();

app.MapGet("/api/categories", async () =>
{
    return await categoryService.GetCategory();
});

app.MapGet("/api/categories/{name}", async (string name) =>
{
    return await categoryService.GetCategoryByName(name);
});

app.MapPost("/api/categories", (Category category) =>
{
    return categoryService.CreateCategory(category);
});


app.MapPut("/api/categories", (Category category) =>
{
    return categoryService.UpdateCategory(category);
});

app.MapDelete("/api/categories/{name}", (string name) =>
{
    return categoryService.DeleteCategory(name);
});

///////////////////////////////////////////////Task////////////////////////////////////////

TaskService taskService = new TaskService();

app.MapGet("/api/tasks", async () =>
{
    return await taskService.GetTasks();
});

app.MapGet("/api/tasks/{taskId}", async (int taskId) =>
{
    return await taskService.GetTaskById(taskId);
});

app.MapPost("/api/tasks", async (Task task) =>
{
    return await taskService.CreateTask(task);
});


app.MapPut("/api/tasks", async (Task taskId) =>
{
    return await taskService.UpdateTask(taskId);
});

app.MapDelete("/api/tasks/{taskId}", async (int taskId) =>
{
    return await taskService.DeleteTask(taskId);
});


////////////////////////////////////////////Comment////////////////////////////////

CommentService commentService = new CommentService();

app.MapGet("/api/comments", async () =>
{
    return await commentService.GetComments();
});

app.MapGet("/api/comments/{commentId}", async (int commentId) =>
{
    return await commentService.GetCommentById(commentId);
});

app.MapPost("/api/comments", async (Comment comment) =>
{
    return await commentService.CreateComment(comment);
});

app.MapPut("/api/comments", async (Comment commentId) =>
{
    return await commentService.UpdateComment(commentId);
});

app.MapDelete("/api/comments/{commentId}", async (int commentId) =>
{
    return await commentService.DeleteComment(commentId);
});

///////////////////////////////////////TaskHistory///////////////////////////////////////////


TaskHistoryService taskHistory = new TaskHistoryService();

app.MapGet("/api/taskhistory", async () =>
{
    return await taskHistory.GetTasksHistory();
});

app.MapGet("/api/taskhistory/{taskId}", async (int taskId) =>
{
    return await taskHistory.GetTaskHistoryById(taskId);
});

app.MapPost("/api/taskhistory", async (TaskHistory history) =>
{
    return await taskHistory.CreateTaskHistory(history);
});

app.MapPut("/api/taskhistory", async (TaskHistory historyId) =>
{
    return await taskHistory.UpdateTaskHistory(historyId);
});

app.MapDelete("/api/taskhistory/{taskId}", async (int taskId) =>
{
    return await taskHistory.DeleteTaskHistory(taskId);
});


/////////////////////////////////////////TaskAttachment////////////////////////////////////////


TaskAttachmentService taskAttachment = new TaskAttachmentService();

app.MapGet("/api/taskattachments", async () =>
{
    return await taskAttachment.GetTaskAttachments();
});

app.MapGet("/api/taskattachments/{attachmentId}", async (int attachmentId) =>
{
    return await taskAttachment.GetTaskAttachmentById(attachmentId);
});

app.MapPost("/api/taskattachments", async (TaskAttachment attachment) =>
{
    return await taskAttachment.CreateTaskAttachment(attachment);
});

app.MapPut("/api/taskattachments", async (TaskAttachment attachmentId) =>
{
    return await taskAttachment.UpdateTaskAttachment(attachmentId);
});

app.MapDelete("/api/taskattachments/{attachmentId}", async (int attachmentId) =>
{
    return await taskAttachment.DeleteTaskAttachment(attachmentId);
});

//////////////////////////////////////////UserWithTheirtasks//////////////////////////////////

UserTasksService userTasksService = new UserTasksService();

app.MapGet("/api/userWithTasks", async () =>
{
    return await userTasksService.GetUserTasks();
});


////////////////////////////////////////categories with a count of tasks in each///////////////////////////////


SumOfCategoryTaskService categoryTaskService = new SumOfCategoryTaskService();

app.MapGet("/api/sumOfCategoryTask", async () =>
{
    return await categoryTaskService.GetCategoryTask();
});

////////////////////////////////////////Get task with high priority////////////////////////////////


GetTaskWithHighPriorityService getTaskWithHighPriorityService = new GetTaskWithHighPriorityService();

app.MapGet("/api/taskWithHighPriority", async () =>
{
    return await getTaskWithHighPriorityService.GetHighPriority();
});

////////////////////////////////////////Get task user category////////////////////////////////'


GetTaskUserCategoryService getTaskUserCategoryService = new GetTaskUserCategoryService();

app.MapGet("/api/taskUserCategory", async () =>
{
    return await getTaskUserCategoryService.GetTaskUserCategory();
});


////////////////////////////////////////Get task by completion date////////////////////////////////'


GetTaskByCompletionDate getTaskByCompletionDateService = new GetTaskByCompletionDate();

app.MapGet("/api/taskByCompletionDate", async () =>
{
    return await getTaskByCompletionDateService.SelectTaskByCompletionDate();
});

////////////////////////////////////////Get task by uuid ////////////////////////////////''

GetTaskHistoryWithUuidService getTaskHistoryWithUuidService = new GetTaskHistoryWithUuidService();

app.MapGet("/api/taskHistoryWithUuid/{taskId}", async (Guid taskId) =>
{
    return await getTaskHistoryWithUuidService.SelectTaskWithUUID(taskId);
});



////////////////////////////////////////Get task in date ////////////////////////////////''



GetTaskInDateService getTaskInDateService = new GetTaskInDateService();

app.MapGet("/api/taskInDate/{duedate}", async (DateTime dueDate) =>
{
    return await getTaskInDateService.GetTaskInDate(dueDate);
});


///////////////////////////////////////Get completed task //////////////////////////////



GetCompletedPriorityTaskService getCompletedTaskService = new GetCompletedPriorityTaskService();

app.MapGet($"/api/completedTasks/{{isCompleted,priority}}", async (bool isCompleted,string priority) =>
{
    return await getCompletedTaskService.GetTaskByCompletionDate(isCompleted,priority);
});


/////////////////////////////////////////////Get comment on task by User////////////////////////////////''


GetCommentOnTaskFByUserService getCommentOnTaskByUserService = new GetCommentOnTaskFByUserService();

app.MapGet("/api/commentOnTaskByUser/{taskId,userName}", async (Guid taskId,Guid userName) =>
{
    return await getCommentOnTaskByUserService.SelectCommentOnTaskFilteredByUser(taskId,userName);
});


/////////////////////////////////////////Get all taskattachments task user //////////////////////////////''


GetAllTaskAttachmentsTaskUserService getAllTaskAttachmentsTaskUserService = new GetAllTaskAttachmentsTaskUserService();

app.MapGet("/api/taskAttachmentsTaskUser/{taskId}", async (Guid taskId) =>
{
    return await getAllTaskAttachmentsTaskUserService.GetAllTaskAttachmentsTaskUsers(taskId);
});

app.Run();










