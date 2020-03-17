using System;

namespace MicroServerless.Sample.Handlers.Commands.Models
{
    public class AddValue
    {
        public Guid Key { get; set; }
        public string Value { get; set; }
    }
}