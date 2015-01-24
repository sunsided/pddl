using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using PDDL.Model.PDDL12.Types;
using Sprache;

namespace PDDL.Parser.PDDL12
{
    /// <summary>
    /// Class TypedLists.
    /// </summary>
    internal static class TypedLists
    {
        /// <summary>
        /// The typed list of type
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<CustomType>> TypedListOfType
            = CreateTypedListOfType();

        /// <summary>
        /// The typed list of name
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IObject>> TypedListOfObject
            = CreateTypedListOfObject();

        /// <summary>
        /// The typed list of variable
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IVariableDefinition>> TypedListOfVariable
            = CreateTypedListOfVariable();


        /// <summary>
        /// The typed list of constant
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IConstant>> TypedListOfConstant
            = CreateTypedListOfConstant();

        /// <summary>
        /// The typed list of domain variable
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IDomainVariable>> TypedListOfDomainVariable
            = CreateTypedListOfDomainVariable();

        #region Factory Functions

        /// <summary>
        /// Creates the typed list (variable)
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Variable&gt;&gt;.</returns>
        private static Parser<IEnumerable<IVariableDefinition>> CreateTypedListOfVariable()
        {
            return (
                from vns in CommonGrammar.VariableName.AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => CommonGrammar.Type).Token().Optional()
                let type = t.IsDefined ? t.Get() : DefaultType.Default
                select vns.Select(vn => new VariableDefinition(new Variable(vn), type))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(v => v));
        }

        /// <summary>
        /// Creates the type list (type)
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;CustomType&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<CustomType>> CreateTypedListOfType()
        {
            return (
                from names in CommonGrammar.NameNonToken.Token().AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => CommonGrammar.Type).Token().Optional()
                select names.Select(vn => new CustomType(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        /// <summary>
        /// Creates the typed list of constant.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Constant&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IConstant>> CreateTypedListOfConstant()
        {
            return (
                from names in CommonGrammar.NameNonToken.Token().AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => CommonGrammar.Type).Token().Optional()
                select names.Select(vn => new Constant(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        /// <summary>
        /// Creates the typed list of domain variable.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Constant&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IDomainVariable>> CreateTypedListOfDomainVariable()
        {
            return (
                from variables in DomainVariableGrammar.DomainVariable.Token().AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => CommonGrammar.Type).Token().Optional()
                select variables.Select(var =>
                                        {
                                            // bind the optional type
                                            if (t.IsDefined) var.Type = t.Get();
                                            return var;
                                        })
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        /// <summary>
        /// Creates the type list (name)
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IObject&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IObject>> CreateTypedListOfObject()
        {
            return (
                from names in CommonGrammar.NameNonToken.Token().AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => CommonGrammar.Type).Token().Optional()
                select names.Select(vn => new Object(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        #endregion Factory Functions
    }
}
