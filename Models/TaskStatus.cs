using System;
using System.Collections.Generic;

namespace Реконструирование
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Tasks = new HashSet<Task>();
        }

        public int TaskStatusId { get; set; }
        public string StatusType { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
