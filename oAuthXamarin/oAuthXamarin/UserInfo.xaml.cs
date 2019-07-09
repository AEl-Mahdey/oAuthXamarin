using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace oAuthXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserInfo : ContentPage
	{
		public UserInfo (User user)
		{
			InitializeComponent ();
            userName.Text = user.FirstName;
            userEmail.Text = user.Email;
            userPicture.Source = user.Picture;
		}

        
        

	}
}