using System;

namespace Zadanie_3.Models
{
    public class WorkItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime EndDate { get; set; }

        public Status CurrentStatus => ResolveStatus();

        private Status ResolveStatus()
        {
            if (this.EndDate.Date <= DateTime.Now.Date) return Status.Overdue;
            return this.EndDate.AddDays(-Constants.DaysToWarn).Date == DateTime.Now.Date ? Status.CloseToOverdue : Status.Active;
        }
    }
}