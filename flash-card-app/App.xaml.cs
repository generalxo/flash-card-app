using flash_card_app.Services;

namespace flash_card_app;

public partial class App : Application
{
    public static DbContext Context { get; private set; }
    public App(DbContext dbContext)
    {
        InitializeComponent();

        MainPage = new AppShell();

        Context = dbContext;
    }
}
