using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public static class CategoryExtensions
    {
        public static KindOfExperience GetKindOfExperience(this Category category)
        {
            int[] pedIds = { 0, 2, 6 };
            return pedIds.Contains(category.id) ? KindOfExperience.Pedagogical : KindOfExperience.Other;
        }
    }

}
