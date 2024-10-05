using System.Collections.Generic;

namespace DeskBooker.Core.DataInterface;

public interface IDeskRepository
{
    IEnumerable<Desk> GetAvailableDesks(DateTime date);
}
