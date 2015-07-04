using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffBonusProject
    {
        public FactStaff FactStaff
        { get; set; }

        public Dep Dep
        {
            get
            {
                return FactStaff.Dep;
            }
        }

        public Post Post
        {
            get
            {
                return FactStaff.Post;
            }
        }

        public WorkType WorkType
        {
            get
            {
                return FactStaff.WorkType;
            }
        }

        public decimal StaffCount
        {
            get
            {
                return FactStaff.StaffCount;
            }
        }
    }
}
