using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GLuaR.Classes.Snippet
{
    public class SnippetManager
    {
        private static readonly Regex Regex = new Regex(@"\$\{(\w+?)\}", RegexOptions.Compiled);
        private Dictionary<string, string> _values = new Dictionary<string, string>();

        public SnippetManager(Dictionary<string, string> values)
        {
            _values = values;
        }

        public Dictionary<string, string> Values
        {
            get { return _values; }
        }

        public string Preprocess(string code)
        {
            return Regex.Replace(code, SubstituteKeyword);
        }

        private string SubstituteKeyword(Match match)
        {
            string key = match.Captures[0].Value;
            if(_values.ContainsKey(key))
            {
                return _values[key];
            }
            return "VALUE NOT FOUND";
        }
    }
}