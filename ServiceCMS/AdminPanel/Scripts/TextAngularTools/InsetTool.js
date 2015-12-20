app.factory("InsetTool", function ($http, $q, taSelection, InsetService) {
    return {
        iconclass: "fa fa-outdent",
        action: function (deferred, restoreSelection) {
            var promise = InsetService.getInset();
            var that = this;
            promise.then(function (inset) {
                var insetElement = "<span class='inset"+inset.name+"'>" + inset.string + "</span>";
                restoreSelection();
                that.$editor().wrapSelection('insertHTML', inset.string, true);
                deferred.resolve();
            }, function () {
                restoreSelection();
            });
            return false;
        }
    }

});