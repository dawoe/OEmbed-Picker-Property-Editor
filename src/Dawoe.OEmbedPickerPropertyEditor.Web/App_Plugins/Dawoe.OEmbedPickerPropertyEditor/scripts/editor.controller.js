(function() {
    'use strict';

    function EditorController($scope, editorService) {
        var vm = this;      

        function openEmbedDialog() {
            var editorOptions = {
                submit: function (model) {
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            }

            editorService.embed(editorOptions);
        }

        vm.open = openEmbedDialog;
    }

    angular.module('umbraco').controller('Dawoe.OEmbedPickerEditorController',
        ['$scope', 'editorService', EditorController]);
})();