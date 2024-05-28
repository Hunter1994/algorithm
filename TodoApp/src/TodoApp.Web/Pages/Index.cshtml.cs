using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.TodoItems;

namespace TodoApp.Web.Pages;

public class IndexModel : TodoAppPageModel
{
    public List<TodoItemDto> TodoItems { get; set; }

    private readonly ITodoAppService _todoAppService;

    public IndexModel(ITodoAppService todoAppService)
    {
        _todoAppService = todoAppService;
    }

    public async Task OnGet()
    {
        TodoItems = await _todoAppService.GetListAsync();
    }
}
