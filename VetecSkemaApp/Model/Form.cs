using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Model
{
    [Serializable]
    public class Form : IForm
    {
        // public int Id { get; set; }
        public int LPCapacity { get; set; }
        public bool OOMvV { get; set; }
        public bool OO420mA { get; set; }
        public bool OO2Wire { get; set; }
        public bool OO3Wire { get; set; }
        public bool OOBSingle { get; set; }
        public bool OOBDouble { get; set; }
        public bool OOBR350 { get; set; }
        public bool OOBR700 { get; set; }
        public bool OOBR1000 { get; set; }
        public bool OOBR2000 { get; set; }
        public bool OOHHose { get; set; }
        public bool WEDry { get; set; }
        public bool WEWet { get; set; }
        public bool WEChem { get; set; }
        public bool WEExpl { get; set; }
        public bool SPRadial { get; set; }
        public bool SPAxial { get; set; }
        public bool SPKeeplateEnd { get; set; }
        public bool SPOtherEnd { get; set; }
        public bool SPGland { get; set; }
        public bool SPConnector { get; set; }
        public bool SPGreaseway { get; set; }
        public int SPCLength { get; set; }
        public int AOLMF { get; set; }                 ////
        public int AOLLF { get; set; }                 ////
        public int AOLHF { get; set; }                 ////
        public int AOLLFDegrees { get; set; }          ////
        public int AOLHFDegrees { get; set; }          ////
        public int DimFPlus { get; set; }
        public int DimA { get; set; }
        public int DimB { get; set; }
        public int DimC { get; set; }
        public int DimD { get; set; }
        public int DimE { get; set; }
        public int DimF { get; set; }
        public int DimG { get; set; }
        public int DimH { get; set; }
        public int DimTol { get; set; }

    }
}
