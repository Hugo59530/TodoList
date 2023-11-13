using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class TodoList
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
