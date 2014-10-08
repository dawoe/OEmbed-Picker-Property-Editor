angular.module('umbraco').controller('Dawoe.EmbedPropertyEditor.Editor', function ($scope, dialogService) {

    $scope.AddEmbed = function () {
        dialogService.embedDialog({
            callback: function (data) {
                $scope.model.value = data;
            }
        });
    };

    $scope.RemoveEmbed = function () {
        $scope.model.value = '';
    }
});