(function() {
    'use strict';

    function EditorController($scope, $sce, editorService) {
        var vm = this;

        vm.items = Array.isArray($scope.model) ? $scope.model : [];

        function openEmbedDialog(embed, onSubmit) {

            const embedDialog = {
                embed: _.clone(embed),
                submit: function (model) {
                    onSubmit(model.embed);
                    editorService.close();
                },
                close: function () {
                    editorService.close();
                }
            };

            editorService.embed(embedDialog);

        }

        function trustHtml(html) {
            return $sce.trustAsHtml(html);
        }

        function addEmbed(evt) {
            evt.preventDefault();

            openEmbedDialog({},
                (newEmbed) => {
                    vm.items.push(newEmbed);
                });
        }    

        function removeEmbed(index, evt) {
            evt.preventDefault();

            vm.items.splice(index, 1);
        }

        vm.add = addEmbed;
        vm.remove = removeEmbed;
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