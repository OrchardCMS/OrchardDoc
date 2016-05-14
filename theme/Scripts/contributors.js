angular.module('ContributorsApp.Controllers', []).
    controller('ContributorsCtrl', function ($scope, $http) {
        $http.get('https://api.github.com/repos/OrchardCMS/OrchardDoc/contributors').
            success(function (data) {
                $scope.totalContributors = data;
            });
    });