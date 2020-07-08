using System;

namespace SumatraPDF
{
    [Obsolete("Please use \"SumatraPDF\" instead.")]
    public class SumatraPDFWrapper : SumatraPDFPrinter
    {
        public SumatraPDFWrapper(
            IProcessFactory processFactory = null)
            : base(processFactory)
        {
        }

        public SumatraPDFWrapper(
            int maxConcurrentPrintings,
            IProcessFactory processFactory = null)
            : base(maxConcurrentPrintings, processFactory)
        {
        }
    }
}
