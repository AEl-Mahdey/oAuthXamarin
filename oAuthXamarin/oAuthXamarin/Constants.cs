using System;
using System.Collections.Generic;
using System.Text;

namespace oAuthXamarin
{
    public static class Constants
    {
        public static string facebookClientId = "1334985533332987";
        public static string facebookRedirectUri = "fb1334985533332987://authorize";
        public static string facebookAuthorizeUri = "https://www.facebook.com/v3.3/dialog/oauth";
        public static string facebookUserInfoUrl = "https://graph.facebook.com/me?fields=email&access_token={accessToken}";

        public static string googleClientId = "367693767145-5is18uoojs3ov2umu3jscbcjbdophdjt.apps.googleusercontent.com";
        public static string googleiOSClientId = "367693767145-dninkab2s8jk37tbgt6mpm84m8p8agfq.apps.googleusercontent.com";
        public static string googleAndroidId = "367693767145-lm6k6hv82rgr7ctr473qq1e23srvdt5n.apps.googleusercontent.com";
        public static string googleRedirectUri = "https://google.com";
        public static string googleScope = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email ";
        public static string googleAuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string googleAccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string googleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
        public static string iOSRedirectUrl = "com.googleusercontent.apps.367693767145-dninkab2s8jk37tbgt6mpm84m8p8agfq:/oauth2redirect";
        public static string AndroidRedirectUrl = "com.googleusercontent.apps.367693767145-lm6k6hv82rgr7ctr473qq1e23srvdt5n:/oauth2redirect";

        public static string microsoftClientId = "2734b3c7-d56c-48f0-b75a-31d327fae3ce";
        public static string microsoftRedirectUri = "https://google.com";
        public static string microsoftAuthorizeUrl = "https://login.microsoftonline.com/ ";
        public static string microsoftUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";




    }
}
    