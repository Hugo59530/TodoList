using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TaskList
    {
        [Key]

        public int ListId { get; set; }

        public string ListName { get; set; }

        public List<Task> Tasks { get; set; }

    }
}
