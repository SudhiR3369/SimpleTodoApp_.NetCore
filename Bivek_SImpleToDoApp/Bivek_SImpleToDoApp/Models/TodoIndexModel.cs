using System.Collections.Generic;

namespace Bivek_SImpleToDoApp.Models
{
    public class TodoIndexModel
    {
        public IEnumerable<TodoTaskViewModel> Tasks { get; set; }
    }
}
