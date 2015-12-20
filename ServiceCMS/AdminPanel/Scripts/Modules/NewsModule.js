app.config(function ($provide) {
    $provide.decorator('taOptions', ['taRegisterTool', '$delegate','InsetTool', function (taRegisterTool, taOptions,InsetTool) {
        // $delegate is the taOptions we are decorating
        // register the tool with textAngular
        taRegisterTool('insetTool', InsetTool);
        // add the button to the default toolbar definition
        taOptions.toolbar.push([]);
        taOptions.toolbar[4].push('insetTool');
        return taOptions;
    }]);
});