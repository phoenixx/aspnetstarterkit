using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.ViewModels.Search
{
    public class GlobalSearchViewModel
    {
        public string SearchTerm { get; set; }

        public List<ConsignmentDetailViewModel> Consignments { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
    }
}