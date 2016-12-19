using MPD.Electio.SDK.NetCore.Internal.DataTypes.EditorTemplating.Enums;

namespace Spa.StarterKit.React.ViewModels.EditorTemplating
{
    public class TemplateFieldViewModel : TemplateNodeViewModel
    {
        public override TemplateNodeType NodeType => TemplateNodeType.Field;

        public string Name { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public FieldType FieldType { get; set; }
        public string CustomFieldType { get; set; }

        public string Value { get; set; }
    }
}