using System.IO;
using System.Text;

namespace GLuaR.Classes
{
    internal class HTML
    {
        private string _code = "";

        public HTML()
        {
        }

        ~HTML()
        {
        }

        public void AddLine(string line)
        {
            _code += line;
        }

        public MemoryStream GetStream()
        {
            string code = _code;
            code = code.Replace("\n", "<br>");
            var str = new MemoryStream(Encoding.ASCII.GetBytes(code));
            return str;
        }

        public void Header()
        {
            AddLine("<html><head><title>Blank</title></head><body>");
        }

        public void Footer()
        {
            AddLine("</body></html>");
        }
    }
}