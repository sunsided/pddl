using System.Globalization;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Values;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Value;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class DomainVariableGrammar.
    /// </summary>
    internal static class DomainVariableGrammar
    {
        /// <summary>
        /// The value
        /// </summary>
        public static readonly Parser<IDecimalValue> IntegerValue = (
            from value in Parse.Digit.AtLeastOnce().Text()
            let number = decimal.Parse(value)
            select new DecimalValue(number)
            ).Token();

        /// <summary>
        /// The value
        /// </summary>
        public static readonly Parser<IDecimalValue> FloatingPointValue = (
            from integer in Parse.Digit.Many().Text()
            from point in Parse.Char('.')
            from fraction in Parse.Digit.AtLeastOnce().Text()
            let value = $"{integer}.{fraction}"
            let number = decimal.Parse(value, CultureInfo.InvariantCulture)
            select new DecimalValue(number)
            ).Token();

        /// <summary>
        /// The value
        /// </summary>
        public static readonly Parser<IValue> Value = FloatingPointValue.Or(IntegerValue);

            /// <summary>
        /// A variable without a value
        /// </summary>
        public static readonly Parser<DomainVariable> Variable = (
            from name in CommonGrammar.NameNonToken.Token()
            select new DomainVariable(name)
            ).Token();

        /// <summary>
        /// A variable without a value
        /// </summary>
        public static readonly Parser<DomainVariable> VariableWithValue = (
            from open in CommonGrammar.OpeningParenthesis
            from name in CommonGrammar.NameNonToken.Token()
            from value in Value
            from close in CommonGrammar.ClosingParenthesis
            select new ConstantDomainVariable(name, value)
            ).Token();

        /// <summary>
        /// The domain variable
        /// </summary>
        public static readonly Parser<DomainVariable> DomainVariable =
            Variable.Or(VariableWithValue).Token();
    }
}
