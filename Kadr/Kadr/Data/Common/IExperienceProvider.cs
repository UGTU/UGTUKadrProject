using System.Collections.Generic;

namespace Kadr.Data.Common
{
    public interface IExperienceProvider
    {
        IList<IEmployeeExperienceRecord> EmployeeExperiences { get; }
    }
}
