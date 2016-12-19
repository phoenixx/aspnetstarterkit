using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.EditorTemplating.Enums;

namespace Spa.StarterKit.React.ViewModels.EditorTemplating
{
    public class TemplateSectionViewModel : TemplateNodeViewModel
    {
        public override TemplateNodeType NodeType => TemplateNodeType.Section;

        public string Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<TemplateFieldViewModel> Fields { get; set; }
        public TemplateSectionType SectionType { get; set; }
    }

}