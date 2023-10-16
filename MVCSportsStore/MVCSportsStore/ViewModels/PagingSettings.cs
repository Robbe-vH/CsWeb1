namespace MVCSportsStore.ViewModels
{
    public static class PagingSettings
    {
        public static int ProductPagination = 4;
        public static bool PagingSettingsPage = false;
    }

    public class PagingsettingsViewModel
    {
        public int ProductPagination { get; set; }
    }
}