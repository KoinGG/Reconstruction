using System;
using System.Collections.Generic;

namespace Реконструирование
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TaskStatusId { get; set; }
        public int CreatingUserId { get; set; }

        public virtual User CreatingUser { get; set; } = null!;
        public virtual TaskStatus TaskStatus { get; set; } = null!;
    }
}
