using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotFirstVersion
{
    public class ErrorFinder
    {
        public void FindErrors(string code, List<int> errorLines)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            var compilation = CSharpCompilation.Create("MyCompilation", syntaxTrees: new[] { syntaxTree });

            var errors = compilation.GetDiagnostics().Where(d => d.Id == "CS1513" || d.Id == "CS1525");
            foreach (var error in errors)
            {
                var lineSpan = error.Location.GetLineSpan();
                var lineNumber = lineSpan.StartLinePosition.Line + 1;
                errorLines.Add(lineNumber);
                Console.WriteLine(error.ToString() + DateTime.Now);
            }
        }
    }
}
