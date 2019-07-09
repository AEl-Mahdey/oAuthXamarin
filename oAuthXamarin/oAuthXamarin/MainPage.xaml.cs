using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Auth;
using Newtonsoft.Json;
using System.Net.Http;


namespace oAuthXamarin
{
    public partial class MainPage : ContentPage
    {
        Account account;
        AccountStore store;
        string appName = "Scribe";
        UserInfo userinfo = new UserInfo();
        User user = new User();
        
        public MainPage()
        {
            InitializeComponent();
            store = AccountStore.Create(); 
        }

        public void OnFacebookLoginClicked(object sender, EventArgs e)
        {
            //account = store.FindAccountsForService("Facebook").FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                Constants.facebookClientId,
                "email",
                new Uri(Constants.facebookAuthorizeUri),
                new Uri(Constants.facebookRedirectUri),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticatorState.authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        public void OnGoogleLoginClicked(object sender, EventArgs e)
        {
            account = store.FindAccountsForService(appName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                Constants.googleiOSClientId,
                null,
                Constants.googleScope,
                new Uri(Constants.googleAuthorizeUrl),
                new Uri(Constants.iOSRedirectUrl),
                new Uri(Constants.googleAccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnGoogleAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticatorState.authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        public void OnMicrosoftLoginClicked(object sender, EventArgs e)
        {
            var authenticator = new OAuth2Authenticator(
                Constants.microsoftClientId,
                "User.Read",
                new Uri(Constants.microsoftAuthorizeUrl),
                new Uri(Constants.microsoftRedirectUri),
                null,
                true);

            authenticator.Completed += OnMicrosoftAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticatorState.authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }

        async void OnMicrosoftAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            string userInfoUrl = "https://graph.microsoft.com/v1.0/me";
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(userInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, appName);
                }

                await store.SaveAsync(account = e.Account, appName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }


        async void OnGoogleAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        { 
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {

                var request = new OAuth2Request("GET", new Uri(Constants.googleUserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, appName);
                }

                await store.SaveAsync(account = e.Account, appName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }


        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            string userInfoUrl = "https://graph.facebook.com/me?fields=email&access_token={accessToken}";
            var authenticator = sender as OAuth2Authenticator;

            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                var request = new OAuth2Request("GET", new Uri(userInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, appName);
                }

                await store.SaveAsync(account = e.Account, appName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }

        async void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
