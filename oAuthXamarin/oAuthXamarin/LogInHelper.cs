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
    public class LogInHelper
    {
        public void Login(string identityProvider)
        {
            switch (identityProvider)
            {
                case "Facebook":
                    {
                        var authenticator = new OAuth2Authenticator(Constants.facebookClientId, "email", new Uri(Constants.facebookAuthorizeUri) , new Uri(Constants.facebookRedirectUri), null, true);
                    }
                    break;
                case "Google":
                    {
                        var authenticator = new OAuth2Authenticator( Constants.googleClientId, null, Constants.googleScope, new Uri(Constants.googleAuthorizeUrl), new Uri(Constants.googleRedirectUri), 
                                                new Uri(Constants.googleAccessTokenUrl), null, true);
                    }
                    break;
                case "Microsoft":
                    break;
                case "Twitter":
                    break;
            }
        }
    }
}
