using System.Collections.Generic;

namespace MFI.Application.Base
{
    public interface MFIResultContract
    {
        bool HasSuccess { get; }

        List<string> Warnings { get; }

        void AddWarning(string message);
    }
}