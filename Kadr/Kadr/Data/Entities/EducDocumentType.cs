using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    public partial class EducDocumentType : INullable
    {
        public static int Attestat = 12;
        public static int Diplom = 11;
        public static int DefualtDopEducationDoc = 13;
        public static int RankDoc = 2;


        public override string ToString()
        {
            return DocTypeName;
        }


    }

    public class NullEducDocumentType : EducDocumentType, INull
    {

        private NullEducDocumentType()
        {
            this.id = 0;
        }

        public static readonly NullEducDocumentType Instance = new NullEducDocumentType();

        public override string ToString()
        {
            return "(Не задан)";
        }

    }
}
