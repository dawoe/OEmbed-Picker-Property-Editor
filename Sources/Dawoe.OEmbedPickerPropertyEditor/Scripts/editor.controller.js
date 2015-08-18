angular.module('umbraco').controller('Dawoe.OEmbedPickerPropertyEditor.Editor', function ($scope, dialogService, notificationsService) {

    if ($scope.model.value === undefined || $scope.model.value === '' || $scope.model.value == null) {
        $scope.model.value = [];
    }

    $scope.AddEmbed = function () {
        dialogService.embedDialog({
            callback: function (data) {
                if (_.indexOf($scope.model.value, data) == -1) {
                    $scope.model.value.push(data);
                } else {
                    notificationsService.error('You all ready have selected this item');
                }
            }
        });
    };

    $scope.RemoveEmbed = function (index) {
        $scope.model.value.splice(index,1);
    }

    //defines the options for the jquery sortable    
    $scope.sortableOptions = {
        axis: 'y',
        cursor: "move",
        handle: ".sorthandle"       
    };
});