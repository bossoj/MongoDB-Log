namespace BJ.MongoDB.Logger
{
    public static class LevelType
    {
        public static readonly string DEBUG = "DEBUG";
        public static readonly string INFO  = "INFO";
        public static readonly string WARN  = "WARN";
        public static readonly string ERROR = "ERROR";
        public static readonly string FATAL = "FATAL";
    }

    public static class Const
    {
        public static readonly string Properties = "Properties";
        public static readonly string Stacktrace = "Stacktrace";
        public static readonly string OperatingSystem = "OS";
    }

}
