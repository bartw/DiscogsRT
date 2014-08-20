using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsRT.Models
{
    public class SearchQuery
    {
        public string Query { get; set; }
        public SearchItemType? Type { get; set; }
        public string Title { get; set; }
        public string Release_title { get; set; }
        public string Credit { get; set; }
        public string Artist { get; set; }
        public string Anv { get; set; }
        public string Label { get; set; }
        public string Genre { get; set; }
        public string Style { get; set; }
        public string Country { get; set; }
        public string Year { get; set; }
        public string Format { get; set; }
        public string Catno { get; set; }
        public string Barcode { get; set; }
        public string Track { get; set; }
        public string Submitter { get; set; }
        public string Contributor { get; set; }

        internal Dictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>();

            AddStringParameter(parameters, "q", Query);

            if (Type != null)
            {
                AddStringParameter(parameters, "type", Type.ToString().ToLower());
            }

            AddStringParameter(parameters, "title", Title);
            AddStringParameter(parameters, "release_title", Release_title);
            AddStringParameter(parameters, "credit", Credit);
            AddStringParameter(parameters, "artist", Artist);
            AddStringParameter(parameters, "anv", Anv);
            AddStringParameter(parameters, "label", Label);
            AddStringParameter(parameters, "genre", Genre);
            AddStringParameter(parameters, "style", Style);
            AddStringParameter(parameters, "country", Country);
            AddStringParameter(parameters, "format", Format);
            AddStringParameter(parameters, "catno", Catno);
            AddStringParameter(parameters, "barcode", Barcode);
            AddStringParameter(parameters, "track", Track);
            AddStringParameter(parameters, "submitter", Submitter);
            AddStringParameter(parameters, "contributor", Contributor);

            return parameters;
        }

        private static void AddStringParameter(Dictionary<string, string> parameters, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                parameters.Add(key, value.UrlEncode());
            }
        }
    }
}
