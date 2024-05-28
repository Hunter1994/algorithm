using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TodoApp.TodoItems
{
    public class TodoItem:AggregateRoot<Guid>
    {
        public string Text { get; set; }

    }
}
