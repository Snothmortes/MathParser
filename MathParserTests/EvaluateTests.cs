using NUnit.Framework;
using Evaluation;

namespace Evaluation.Tests
{
    using static Evaluation.Evaluate;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System;

    [TestFixture()]
    public class EvaluateTests
    {
        [TestCase("1+2", "3")]
        [TestCase("5-3", "2")]
        [TestCase("12*3", "36")]
        [TestCase("12/3", "4")]
        [TestCase("2&3", "8")]
        public void evalShould_EvaluateBasicArithmetic(string expression, string answer) => Assert.That(eval(expression), Is.EqualTo(answer));

        [TestCaseSource(nameof(SeparateTermsData))]
        public void SeparateTermsShould_SeparateTerms(List<string> actual, List<string> expected) {
            Assert.That(actual.SequenceEqual(expected));
        }

        [TestCaseSource(nameof(DissolveDashesData))]
        public void DissolveDashesShould_Work(string actual, string expected) {
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(CalculateTermData))]
        public void CalculateTermShould_HandleBivalueTerms(string actual, string expected) {
            Assert.That(actual, Is.EqualTo(expected));
        }

        private static IEnumerable<TestCaseData> CalculateTermData() {
            yield return new TestCaseData("5*6", "30");
            yield return new TestCaseData("10/2", "5");
            yield return new TestCaseData("2&3", "8");
        }

        private static IEnumerable<TestCaseData> SeparateTermsData() {
            yield return new TestCaseData("5--6".SeparateTerms(), new List<string>() { "5", "6" });
            yield return new TestCaseData("5-6".SeparateTerms(), new List<string>() { "5", "-6" });
            yield return new TestCaseData("2*3+2&2*4-5".SeparateTerms(), new List<string>() { "2*3", "2&2*4", "-5" });
        }

        private static IEnumerable<TestCaseData> DissolveDashesData() {
            yield return new TestCaseData("-----6".DissolveDashes(), "-6");
            yield return new TestCaseData("----6".DissolveDashes(), "+6");
        }
    }
}