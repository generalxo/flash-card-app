﻿using flash_card_app.Views;

namespace flash_card_app;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(FlashCardPage), typeof(FlashCardPage));
        Routing.RegisterRoute(nameof(EditCardsPage), typeof(EditCardsPage));
        Routing.RegisterRoute(nameof(AddCardPage), typeof(AddCardPage));
    }
}
