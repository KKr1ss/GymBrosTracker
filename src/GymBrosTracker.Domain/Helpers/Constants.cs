namespace GymBrosTracker.Domain.Helpers
{
    public static class Constants
    {
        public static string DBName = "gymbros_database.db3";
        public static string LogName = "gymbros-.log";
        public static string Folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string DBPath = Path.Combine(Folder, DBName);
        public static string LogPath = Path.Combine(Folder, LogName);
    }
}
