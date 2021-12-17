using System.Linq;
using System.Runtime.InteropServices;

namespace Evaluation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class Evaluate
    {
        // ReSharper disable once InconsistentNaming
        public static string eval(string expression) {
            var list = expression.SeparateTerms();


            return "";
        }

        public static List<string> SeparateTerms(this string input) => new Regex(@"\+|(?=-)").Split(input.DissolveDashes()).ToList();

        public static string DissolveDashes(this string input) => new Regex(@"-+").Replace(input, x => x.Length % 2 == 0 ? "+" : "-");

        public static string CalculateTerm(this string term) {
            throw new NotImplementedException();
        }
    }
}
