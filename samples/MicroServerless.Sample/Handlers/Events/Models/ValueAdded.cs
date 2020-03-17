using System;

namespace MicroServerless.Sample.Handlers.Events.Models
{
    public class ValueAdded
    {
        public Guid Key { get; set; }
        public string Value { get; set; }
    }
}