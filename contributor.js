function OrchardContributor($scope, $http) {
    $http.get('https://api.github.com/repos/OrchardCMS/OrchardDoc/contributors').
        success(function(data) {
            $scope.totalContribtors = data;
        });
}