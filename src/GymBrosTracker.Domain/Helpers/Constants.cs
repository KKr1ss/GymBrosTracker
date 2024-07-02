namespace GymBrosTracker.Domain.Helpers
{
    public static class Constants
    {
        public static string DBName = "gymbros_database.db3";
        public static string DBFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static string DBPath = Path.Combine(DBName, DBFolder);
    }
}
