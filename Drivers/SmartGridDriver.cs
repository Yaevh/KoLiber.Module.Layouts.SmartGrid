using System.Linq;
using KoLiber.Module.Layouts.SmartGrid.Elements;
using KoLiber.Module.Layouts.SmartGrid.ViewModels;
using Orchard.ContentManagement;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.MediaLibrary.Models;

namespace KoLiber.Module.Layouts.SmartGrid.Drivers {

    public class SmartGridDriver : ElementDriver<Elements.SmartGrid> {

        private readonly IContentManager _contentManager;

        public SmartGridDriver(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        protected override EditorResult OnBuildEditor(Elements.SmartGrid element, ElementEditorContext context) {
            var viewModel = new SmartGridViewModel {
                BackgroundImageId = element.BackgroundImageId != null ? element.BackgroundImageId.ToString() : null,
                BackgroundSize = element.BackgroundSize,
                CustomClass = element.CustomClass
            };

            // If an Updater is specified,
            // it means the element editor form is being submitted
            // and we need to read and store the submitted data.
            if (context.Updater != null) {
                if (context.Updater.TryUpdateModel(viewModel, context.Prefix, null, null)) {
                    element.BackgroundImageId = Orchard.Layouts.Elements.ContentItem.Deserialize(viewModel.BackgroundImageId).FirstOrDefault();
                    element.BackgroundSize = viewModel.BackgroundSize != null ? viewModel.BackgroundSize.Trim() : null;
                    element.CustomClass = viewModel.CustomClass != null ? viewModel.CustomClass.Trim() : null;
                }
            }
            viewModel.BackgroundImage = GetBackgroundImage(element, VersionOptions.Latest);
            var editorTemplate = context.ShapeFactory.EditorTemplate(
                TemplateName: "Elements/SmartGrid",
                Model: viewModel,
                Prefix: context.Prefix);

            return Editor(context, editorTemplate);
        }

        protected override void OnDisplaying(Elements.SmartGrid element, ElementDisplayingContext context) {
            var versionOptions = context.DisplayType == "Design"
                ? VersionOptions.Latest : VersionOptions.Published;
            context.ElementShape.BackgroundImage = GetBackgroundImage(element, versionOptions);
        }

        protected override void OnExporting(Elements.SmartGrid element, ExportElementContext context) {
            // Load the actual background content item.
            var backgroundImage = GetBackgroundImage(element, VersionOptions.Latest);
            if (backgroundImage == null)
                return;

            // Use the content manager to get the content identities.
            var backgroundImageIdentity = _contentManager.GetItemMetadata(backgroundImage).Identity;

            // Add the content item identities to the ExportableData dictionary.
            context.ExportableData["BackgroundImage"] = backgroundImageIdentity.ToString();
        }

        protected override void OnImporting(Elements.SmartGrid element, ImportElementContext context) {
            // Read the imported content identity from
            // the ExportableData dictionary.
            var backgroundImageIdentity = context.ExportableData.Get("BackgroundImage");

            // Get the imported background content item from
            // the ImportContentSesison store.
            var backgroundImage = context.Session.GetItemFromSession(backgroundImageIdentity);
            if (backgroundImage == null)
                return;

            // Get the background content item id (primary key value)
            // for each background image.
            var backgroundImageId = backgroundImage.Id;

            // Assign the content id to the BackgroundImageId property so
            // that they contain the correct values, instead of the
            // automatically imported value.
            element.BackgroundImageId = backgroundImageId;
        }

        private ImagePart GetBackgroundImage(Elements.SmartGrid element, VersionOptions options) {
            return element.BackgroundImageId != null
                ? _contentManager.Get<ImagePart>(element.BackgroundImageId.Value, options, QueryHints.Empty.ExpandRecords<MediaPartRecord>())
                : null;
        }
    }
}