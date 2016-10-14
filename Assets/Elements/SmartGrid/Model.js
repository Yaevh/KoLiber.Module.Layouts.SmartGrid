var LayoutEditor;

(function (LayoutEditor) {
    // The constructor.
    LayoutEditor.SmartGrid = function (data, contentType, htmlId, htmlClass, htmlStyle, isTemplated, rule, hasEditor, children) {

        var self = this;

        // Inherit from the Element base class.
        LayoutEditor.Element.call(self, "SmartGrid", data, htmlId, htmlClass, htmlStyle, isTemplated, rule);
        
        // Inherit from the Container base class.
        //LayoutEditor.Container.call(self, ["Canvas", "Grid", "Content"],  children);
        LayoutEditor.Container.call(this, ["Row"], children);

        // This SmartGrid element is containable, which means it can be added
        // to any container, including SmartGrids.
        self.isContainable = true;

        // Used by the layout editor to determine if it should launch
        // the element editor dialog when creating new SmartGride elements.
        // Also used by our "LayoutEditor.Template.SmartGrid.cshtml" view
        // that is used as the layout‐smart-grid directive's template.
        self.hasEditor = hasEditor;

        // The element type name, which is sent back to the
        // element editor controller when being edited.
        self.contentType = contentType;
        
        // The "layout‐common‐holder" CSS class is used by the layout editor
        // to identify drop targets.
        self.dropTargetClass = "layout‐common‐holder";
        // Implements the toObject serialization function.
        // This is called when the layout is being serialized into JSON.
        var toObject = self.toObject;
        
        // Get a reference to the base function.
        self.toObject = function () {
            var result = toObject();
            // Invoke the base implementation.
            result.children = self.childrenToObject();
            return result;
        };
    };
    
    // Registers the factory function with the element factory.
    LayoutEditor.registerFactory("SmartGrid", function (value) {
        var smartGrid = new LayoutEditor.SmartGrid(
            value.data,
            value.contentType,
            value.htmlId,
            value.htmlClass,
            value.htmlStyle,
            value.isTemplated,
            value.rule,
            value.hasEditor,
            LayoutEditor.childrenFrom(value.children));
        
        // Initializes the toolbox specific properties.
        smartGrid.toolboxIcon = value.toolboxIcon;
        smartGrid.toolboxLabel = value.toolboxLabel;
        smartGrid.toolboxDescription = value.toolboxDescription;

        return smartGrid;
    });
})(LayoutEditor || (LayoutEditor = {}));