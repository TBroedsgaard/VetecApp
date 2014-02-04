using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IForm
    {
        int Id { get; set; }
        
        int LPCapacity { get; set; }

        bool OOMvV { get; set; }
        bool OO420mA { get; set; }
        bool OO2Wire { get; set; }
        bool OO3Wire { get; set; }
        bool OOBSingle { get; set; }
        bool OOBDouble { get; set; }
        bool OOBR700 { get; set; }
        bool OOBR1000 { get; set; }
        bool OOBR2000 { get; set; }
        bool OOHHose { get; set; }
        
        bool WEDry { get; set; }
        bool WEWet { get; set; }
        bool WEChem { get; set; }
        bool WEExpl { get; set; }

        bool SPRadial { get; set; }
        bool SPAxial { get; set; }
        bool SPKeeplateEnd { get; set; }
        bool SPOtherEnd { get; set; }
        bool SPGland { get; set; }
        bool SPConnector { get; set; }
        bool SPGreaseway { get; set; }
        int SPCLength { get; set; }

        int AOLMF { get; set; }
        int AOLLF { get; set; }
        int AOLHF { get; set; }
        int AOLLFDegrees { get; set; }
        int AOLHFDegrees { get; set; }

        int DimFPlus { get; set; }
        int DimA { get; set; }
        int DimB { get; set; }
        int DimD { get; set; }
        int DimE { get; set; }
        int DimF { get; set; }
        int DimG { get; set; }
        int DimTol { get; set; }
        int DimC { get; set; }
        int DimH { get; set; }

        bool OOBR350 { get; set; }
    }
}
