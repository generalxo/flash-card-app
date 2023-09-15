namespace flash_card_app.Helpers
{
    public class ErrorHandler
    {
        public async Task DisplayErrorMsgAsync(Exception exception)
        {
            await Shell.Current.DisplayAlert("Edit Card Error", exception.Message, "OK");
        }
    }
}
