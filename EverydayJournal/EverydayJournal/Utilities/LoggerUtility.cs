namespace EverydayJournal.Utilities
{
    public static class LoggerUtility
    {
        private static int? userId;
        public static int? UserId { get { return userId; } set { userId = value; } }

        private static string userName;
        public static string UserName { get { return userName; } set { userName = value;} }
    }
}
