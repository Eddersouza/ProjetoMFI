using System.Collections.Generic;

namespace MFI.Application.Base
{
    public class MFIResult : MFIResultContract
    {
        private List<string> warnings = new List<string>();
        public bool HasSuccess => Warnings.Count.Equals(0);

        public List<string> Warnings => warnings;

        public void AddWarning(string message)
        {            
            Warnings.Add(message);
        }
    }
}