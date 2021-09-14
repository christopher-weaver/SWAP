using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAP.Data.DataModels.Enumerations
{
    public enum Category
    {
        CIA = 0,
        SIT,
        STEM,
        EESAnalytics
    }

    public enum Subcategory
    {
        AssessmentDevelopment = 0,
        CurriculumRefinement,
        CurriculumMappingELA,
        CurriculumMappingMath,
        CurriculumMappingSci,
        CurriculumMappingSoc,
        SIG1003g,
        MathPerformanceTask,
        MathReasoningPD,
        LiteracyPlan,
        CurriculumInquiryCycle,
        Miscellaneous,
        IPMWholeStaff,
        IPMMicrocredentialing,
        LPP,
        SPEDAudit,
        LiteracyBank,
        GradPathwaysAudit,
        SELFramework,
        SIP,
        STEMCertification,
        PBLMicrocredentialing,
        PBLL14STEMCertification,
        PBLL1nonSTEM,
        C2TCurriculum
    }

    public enum Status
    {
        NotStarted = 0,
        InProgress,
        Completed
    }
}
