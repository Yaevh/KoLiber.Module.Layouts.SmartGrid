using Orchard.MediaLibrary.Models;

namespace KoLiber.Module.Layouts.SmartGrid.ViewModels {
    public class SmartGridViewModel {

        public string BackgroundImageId { get; set; }
        public string BackgroundSize { get; set; }
        public ImagePart BackgroundImage { get; set; }
        public string CustomClass { get; set; }
    }
}
