angular.module('umbraco').controller('Dawoe.OEmbedPickerPropertyEditor.Editor', function ($scope, dialogService, notificationsService) {

    $scope.init = function () {
        if ($scope.model.value === undefined || $scope.model.value === '' || $scope.model.value == null) {
            $scope.model.value = [];
        }
    }
    
    $scope.AddEmbed = function () {
        $scope.init();
        dialogService.embedDialog({
            callback: function (data) {
                if (_.indexOf($scope.model.value, data) == -1) {
                    $scope.model.value.push(data);
                } else {
                    notificationsService.error('You have already selected this item');
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

    $scope.$on("formSubmitting", function (ev, args) {
        if ($scope.model.validation.mandatory && $scope.model.value.length == 0) {
            $scope.model.value = null;
        }
    });

    $scope.init();
});