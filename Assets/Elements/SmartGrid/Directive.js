angular
    .module("LayoutEditor")
    .directive("orcLayoutSmartgrid", [
        "scopeConfigurator",
        "environment",
        function (scopeConfigurator, environment) {
            return {
                restrict: "E",
                scope: { element: "=" },
                controller: [
                    "$scope",
                    "$element",
                    "$attrs",
                    function ($scope, $element, $attrs) {
                        scopeConfigurator.configureForElement($scope, $element);
                        scopeConfigurator.configureForContainer($scope, $element);
                        $scope.sortableOptions["axis"] = "y";
                    }
                ],
                templateUrl: environment.templateUrl("SmartGrid"),
                replace: true
            };
        }
    ]);