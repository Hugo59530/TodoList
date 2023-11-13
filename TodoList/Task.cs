using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class Task
    {
        public int taskId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public string taskStatus { get; set; }
        public int ListId { get; set; }
        public virtual TaskList TaskList { get; set; }
    }

}
