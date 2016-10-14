using Orchard.Layouts.Elements;
using Orchard.Layouts.Helpers;

namespace KoLiber.Module.Layouts.SmartGrid.Elements {

    public class SmartGrid : Container {

        public override string Category { get { return "Layout"; } }

        public override string ToolboxIcon { get { return "\uf03e"; } }

        public int? BackgroundImageId
        {
            get { return this.Retrieve(x => x.BackgroundImageId); }
            set { this.Store(x => x.BackgroundImageId, value); }
        }

        public string BackgroundSize
        {
            get { return this.Retrieve(x => x.BackgroundSize); }
            set { this.Store(x => x.BackgroundSize, value); }
        }

        public string CustomClass
        {
            get { return this.Retrieve(x => x.CustomClass); }
            set { this.Store(x => x.CustomClass, value); }
        }
    }

}