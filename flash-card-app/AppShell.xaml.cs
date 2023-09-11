using flash_card_app.Views;

namespace flash_card_app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(CardDeckPage), typeof(CardDeckPage));
		Routing.RegisterRoute(nameof(CreateDeckPage), typeof(CreateDeckPage));
		Routing.RegisterRoute(nameof(CardsPage), typeof(CardsPage));
		Routing.RegisterRoute(nameof(CreateCardPage), typeof(CreateCardPage));
	}
}
