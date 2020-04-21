using System.Globalization;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Value;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class DomainVariableGrammar.
    /// </summary>
    internal sealed class DomainVariableParser : ParserBase<DomainVariable>
    {
        public DomainVariableParser(NameNonTokenParser nameNonTokenParser, ParenthesisParser parenthesisParser)
        {
            IntegerValue = (
                from value in Parse.Digit.AtLeastOnce().Text()
                let number = decimal.Parse(value)
                select new DecimalValue(number)
            ).Token();

            FloatingPointValue = (
                from integer in Parse.Digit.Many().Text()
                from point in Parse.Char('.')
                from fraction in Parse.Digit.AtLeastOnce().Text()
                let value = $"{integer}.{fraction}"
                let number = decimal.Parse(value, CultureInfo.InvariantCulture)
                select new DecimalValue(number)
            ).Token();

            Value = FloatingPointValue.Or(IntegerValue);

            Variable = (
                from name in nameNonTokenParser.Token()
                select new DomainVariable(name)
            ).Token();

            VariableWithValue = (
                from open in parenthesisParser.Opening
                from name in nameNonTokenParser.Token()
                from value in Value
                from close in parenthesisParser.Closing
                select new ConstantDomainVariable(name, value)
            ).Token();

            Parser = Variable.Or(VariableWithValue).Token();
        }

        /// <summary>
        /// The domain variable
        /// </summary>
        public override Parser<DomainVariable> Parser { get; }

        internal Parser<DecimalValue> IntegerValue { get; }
        internal Parser<DecimalValue> FloatingPointValue { get; }
        internal Parser<DecimalValue> Value { get; }
        internal Parser<DomainVariable> Variable { get; }
        internal Parser<ConstantDomainVariable> VariableWithValue { get; }

    }
}
