using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBase.Shared.Domain.Model;

public class Track
{
    private List<Position> Positions { get; }

    public Track(List<Position> positions)
    {
        Positions = positions;
    }

    public bool IsEmpty()
    {
        return Positions.Count == 0;
    }

    public bool Clear()
    {
        Positions.Clear();
        return true;
    }

    public bool Add(Position position)
    {
        Positions.Add(position);
        return true;
    }

    public bool AddRange(List<Position> positions)
    {
        Positions.AddRange(positions);
        return true;
    }

    public bool Remove(Position position)
    {
        Positions.Remove(position);
        return true;
    }
}

