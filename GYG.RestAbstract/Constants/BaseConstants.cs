namespace GYG.RestAbstract.Constants
{
    public struct BaseConstants
    {
        public struct MessageTypes
        {
            public const string Error = "error";
            public const string Info = "info";
            public const string Warning = "warning";
            public const string Success = "success";
        }
        public struct ExceptionCodes
        {
            public const string UniqueIndex = "UniqueIndex";
            public const string NotValidModel = "NotValidModel";
        }
        public const string LoggerFactory = "LoggerFactory";
        public const string Configuration = "Configuration";
    }
}
