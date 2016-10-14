using Orchard.UI.Resources;

namespace KoLiber.Module.Layouts.SmartGrid.ResourceManifests {
    public class SmartGridResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineStyle("SmartGridElement").SetUrl("SmartGridElement.min.css", "SmartGridElement.css");
            manifest.DefineScript("SmartGridElement").SetUrl("SmartGridElement.min.js", "SmartGridElement.js").SetDependencies("Layouts.LayoutEditor");
        }
    }
}
