using System;
using System.Collections.Generic;

namespace DeskBooker.Core.Tests
{
    internal class DeskBookingResult
    {
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public string Email { get; internal set; }

        public DateTime Date { get; internal set; }
    }
}