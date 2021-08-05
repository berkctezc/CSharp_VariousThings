using System;

namespace xUnitTutorial
{
    public class GuidGenerator
    {
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}