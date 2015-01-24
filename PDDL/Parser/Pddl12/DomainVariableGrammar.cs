﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static Parser<IDecimalValue> DecimalValue = (
            from value in Parse.Digit.AtLeastOnce().Text()
            let number = Decimal.Parse(value)
            select new DecimalValue(number)
            );

        /// <summary>
        /// The value
        /// </summary>
        [NotNull]
        public static Parser<IValue> Value =
            DecimalValue;

            /// <summary>
        /// A variable without a value
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainVariable> Variable = (
            from name in CommonGrammar.NameNonToken.Token()
            select new DomainVariable(name)
            );

        /// <summary>
        /// A variable without a value
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainVariable> VariableWithValue = (
            from open in CommonGrammar.OpeningParenthesis
            from name in CommonGrammar.NameNonToken.Token()
            from value in Value
            from close in CommonGrammar.ClosingParenthesis
            select new ConstantDomainVariable(name, value)
            );

        /// <summary>
        /// The domain variable
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainVariable> DomainVariable =
            Variable.Or(VariableWithValue);
    }
}
