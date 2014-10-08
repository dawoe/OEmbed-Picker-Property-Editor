angular.module('umbraco').controller('Dawoe.EmbedPropertyEditor.Editor', function ($scope, dialogService) {

    if ($scope.model.value === undefined || $scope.model.value === '') {
        $scope.model.value = [];
    }

    $scope.AddEmbed = function () {
        dialogService.embedDialog({
            callback: function (data) {
                $scope.model.value.push(data);
            }
        });
    };

    $scope.RemoveEmbed = function () {
        $scope.model.value = '';
    }
});