using System.Configuration;

namespace MFI.Utils
{
    public class MFISetting
    {        
        public static string CorsSite => ConfigurationManager.AppSettings["CorsSite"] ?? string.Empty;
        public static string ConnectionStringBase => ConfigurationManager.AppSettings["ConnectionStringBase"] ?? string.Empty;
        public static string SchemaMFI => ConfigurationManager.AppSettings["SchemaMFI"] ?? string.Empty;
    }
}