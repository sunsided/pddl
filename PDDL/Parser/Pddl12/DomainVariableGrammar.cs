using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Value;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class DomainVariableGrammar.
    /// </summary>
    internal static class DomainVariableGrammar
    {
        /// <summary>
        /// The value
        /// </summary>
        [NotNull] 
        public static Parser<IDecimalValue> IntegerValue = (
            from value in Parse.Digit.AtLeastOnce().Text()
            let number = Decimal.Parse(value)
            select new DecimalValue(number)
            ).Token();

        /// <summary>
        /// The value
        /// </summary>
        [NotNull]
        public static Parser<IDecimalValue> FloatingPointValue = (
            from integer in Parse.Digit.Many().Text()
            from point in Parse.Char('.')
            from fraction in Parse.Digit.AtLeastOnce().Text()
            let value = String.Format("{0}.{1}", integer, fraction)
            let number = Decimal.Parse(value, CultureInfo.InvariantCulture)
            select new DecimalValue(number)
            ).Token();

        /// <summary>
        /// The value
        /// </summary>
        [NotNull]
        public static Parser<IValue> Value =
            FloatingPointValue.Or(IntegerValue);

            /// <summary>
        /// A variable without a value
        /// </summary>
        [NotNull]
        public static readonly Parser<DomainVariable> Variable = (
            from name in CommonGrammar.NameNonToken.Token()
            select new DomainVariable(name)
            ).Token();

        /// <summary>
        /// A variable without a value
        /// </summary>
        [NotNull]
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
        [NotNull]
        public static readonly Parser<DomainVariable> DomainVariable =
            Variable.Or(VariableWithValue).Token();
    }
}
