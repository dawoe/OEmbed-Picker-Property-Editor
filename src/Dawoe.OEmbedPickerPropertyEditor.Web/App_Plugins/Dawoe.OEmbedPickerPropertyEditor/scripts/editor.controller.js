(function() {
    'use strict';

    function EditorController($scope, $sce, editorService) {
        var vm = this;

        vm.items = Array.isArray($scope.model) ? $scope.model : [];
        
        function openEmbedDialog() {
            var editorOptions = {
                submit: function (model) {
                    console.log(model);

                    var item = model.embed;

                    vm.items.push(item);

                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            }

            editorService.embed(editorOptions);
        }

        function trustHtml(html) {
            return $sce.trustAsHtml(html);
        }

        vm.open = openEmbedDialog;
        vm.trustHtml = trustHtml;

        vm.sortableOptions = {
            axis: 'y',
            containment: 'parent',
            cursor: 'move',
            items: '> .umb-table-row',
            handle: '.handle',
            tolerance: 'pointer'
        };

    }

    angular.module('umbraco').controller('Dawoe.OEmbedPickerEditorController',
        ['$scope', '$sce', 'editorService', EditorController]);
})();