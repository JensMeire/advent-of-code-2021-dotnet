using System.Collections;
using System.Collections.Generic;

namespace D3_BinaryDiagnostic
{
    public interface IReportGenerator
    {
        List<string> Generate();
    }
}