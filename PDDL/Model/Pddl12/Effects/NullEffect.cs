﻿using JetBrains.Annotations;
using PDDL.Model.Pddl12.Null;

namespace PDDL.Model.Pddl12.Effects
{
    /// <summary>
    /// Class NullEffect.
    /// </summary>
    public sealed class NullEffect : EffectBase
    {
        /// <summary>
        /// The default instance
        /// </summary>
        [NotNull]
        private static readonly NullEffect _default = new NullEffect();

        /// <summary>
        /// Returns the default instance of the <see cref="NullEffect"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullEffect Default { get { return _default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullEffect"/> class.
        /// </summary>
        public NullEffect() : base(ListType.Indifferent)
        {
        }
    }
}
