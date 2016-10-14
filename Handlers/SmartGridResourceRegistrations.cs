using Orchard.DisplayManagement.Descriptors;
using Orchard.Environment;
using Orchard.UI.Resources;

namespace KoLiber.Module.Layouts.SmartGrid.Handlers {
    public class SmartGridResourceRegistrations : IShapeTableProvider {
        private readonly Work<IResourceManager> _resourceManager;

        public SmartGridResourceRegistrations(Work<IResourceManager> resourceManager) {
            _resourceManager = resourceManager;
        }

        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("EditorTemplate")
                .OnDisplaying(context => {
                    if (context.Shape.TemplateName != "Parts.Layout")
                        return;
                    _resourceManager.Value.Require("stylesheet", "SmartGridElement");
                    _resourceManager.Value.Require("script", "SmartGridElement");
                });
        }
    }
}
