using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Utils
{
    public class Validations
    {
        public bool ValidationDataCount(int count)
        {
            int restrictionValue = 0;
            var IsValid = count > restrictionValue;
            return IsValid;
        }

        public bool IsNotNull(object parameterFromDatabase)
        {
            var IsValid = parameterFromDatabase != null;
            return IsValid;
        }

    }
}
