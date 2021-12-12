using WMS.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace WMS.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
