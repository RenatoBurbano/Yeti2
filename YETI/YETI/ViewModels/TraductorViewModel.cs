using Acr.UserDialogs;
using Nancy.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YETI.ViewModels
{
    public class TraductorViewModel : ViewModelBase
    {
        public DelegateCommand TraducirCommand { get; set; }
        public TraductorViewModel(INavigationService navigationService, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _navigationService = navigationService;
            _userDialogs = userDialogs;
            TraducirCommand = new DelegateCommand(Traducir);
        }

        private void Traducir()
        {
            string text="holi", from="es", to="en";
       
            using (_userDialogs.Loading("Cargando"))
            {
                from = from.ToLower();
                to = to.ToLower();

                // normalize the culture in case something like en-us was passed 
                // retrieve only en since Google doesn't support sub-locales
                string[] tokens = from.Split('-');
                if (tokens.Length > 1)
                    from = tokens[0];

                // normalize to
                tokens = to.Split('-');
                if (tokens.Length > 1)
                    to = tokens[0];

                string url = string.Format(@"http://translate.google.com/translate_a/t?client=j&text={0}&hl=en&sl={1}&tl={2}",
                                           HttpUtility.UrlEncode(text), from, to);

                // Retrieve Translation with HTTP GET call
                string html = null;
                try
                {
                    WebClient web = new WebClient();

                    // MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
                    web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                    web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

                    // Make sure we have response encoding to UTF-8
                    web.Encoding = Encoding.UTF8;
                    html = web.DownloadString(url);
                }
                catch (Exception e)
                {
                    _userDialogs.Alert(e.Message);
                }

                // Extract out trans":"...[Extracted]...","from the JSON string
                string result = Regex.Match(html, "trans\":(\".*?\"),\"", RegexOptions.IgnoreCase).Groups[1].Value;

                if (string.IsNullOrEmpty(result))
                {
                }

                //return WebUtils.DecodeJsString(result);

                // Result is a JavaScript string so we need to deserialize it properly
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string resultado = ser.DeserializeObject(result) as string;
            }
        }

        #region Helpers
        private readonly INavigationService _navigationService;
        private readonly IUserDialogs _userDialogs;
        #endregion Helpers

    }
}
