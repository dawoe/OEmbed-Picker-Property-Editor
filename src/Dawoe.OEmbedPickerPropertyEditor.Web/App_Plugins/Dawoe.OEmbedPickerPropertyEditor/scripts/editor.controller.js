(function() {
    'use strict';

    function EditorController($scope, $sce, editorService) {
        var vm = this;

        vm.allowMultiple = $scope.model.config.allowmultiple;

        vm.items = Array.isArray($scope.model.value) ? $scope.model.value : [];

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
                    vm.items.push({
                        'url': newEmbed.url,
                        'width': newEmbed.width,
                        'height': newEmbed.height,
                        'preview' : newEmbed.preview
                    });
                    updateModelValue();
                });
        }    

        function editEmbed(index, evt) {
            evt.preventDefault();

            var embed = vm.items[index];

            openEmbedDialog(embed,
                (newEmbed) => {
                    vm.items.push({
                        'url': newEmbed.url,
                        'width': newEmbed.width,
                        'height': newEmbed.height,
                        'preview': newEmbed.preview
                    });
                    updateModelValue();
                });
        }

        function removeEmbed(index, evt) {
            evt.preventDefault();

            vm.items.splice(index, 1);

            updateModelValue();
        }

        function updateModelValue() {
            $scope.model.value = vm.items;
            if (vm.oembedform && vm.oembedform.itemCount) {
                vm.oembedform.itemCount.$setViewValue(vm.items.length);
            }
        }

        function validate() {
            var isValid = true;

            if ($scope.model.validation.mandatory && (Array.isArray(vm.items) === false || vm.items.length === 0)) {
                isValid = false;
            } 

            return {
                isValid: isValid,
                errorMsg: "Value cannot be empty",
                errorKey: "required"
            };
        }

        vm.add = addEmbed;
        vm.edit = editEmbed;
        vm.remove = removeEmbed;
        vm.trustHtml = trustHtml;
        vm.validateMandatory = validate;

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