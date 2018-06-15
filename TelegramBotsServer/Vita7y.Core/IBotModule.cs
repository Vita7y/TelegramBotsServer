using System;

namespace Vita7y.Core
{
    public interface IBotModule: IDisposable
    {
        string Name { get; }

        Version Version { get; }
    }
}