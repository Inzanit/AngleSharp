﻿namespace AngleSharp.Css.Conditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    sealed class OrCondition : CssCondition
    {
        readonly CssCondition[] _conditions;

        public OrCondition(IEnumerable<CssCondition> conditions)
        {
            _conditions = conditions.ToArray();
        }
        
        protected override String Serialize()
        {
            return String.Join(" or ", _conditions.Select(m => m.Text));
        }

        public override Boolean Check()
        {
            foreach (var condition in _conditions)
            {
                if (condition.Check() == true)
                    return true;
            }

            return false;
        }
    }
}
