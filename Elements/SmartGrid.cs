using Orchard.Layouts.Elements;
using Orchard.Layouts.Helpers;

namespace KoLiber.Module.Layouts.SmartGrid.Elements {

    public class SmartGrid : Container {

        public override string Category => "Demo";

        public override string ToolboxIcon => "\uf03e";

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
    }

}