using System;
using System.Collections.Generic;
using System.Text;

namespace APG.Base
{
    public interface ITransacted
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
