using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLuaR.Classes.Snippet;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string,string>();
            dict["foo"] = "bar";
            SnippetManager man = new SnippetManager(dict);
            Console.WriteLine(man.Preprocess("${foo} -- ${bar}"));
            Console.ReadLine();
        }
    }
}
