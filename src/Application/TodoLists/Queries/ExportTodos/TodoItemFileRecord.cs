using WMS.Application.Common.Mappings;
using WMS.Domain.Entities;

namespace WMS.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
