var app = angular.module("kioskApp", []);

app.controller("utilisateurController", function($scope,$http) {
    $scope.user = {firstName:"",lastName:"",email:"",password:"",confirmPassword:""};
	//signin
     $scope.signin = function() { 
		console.log("in");
		// $http.get('http://localhost:55185/api/Utilisateurs?email=aa@aaa.coom&password=aaa')
		 $http.get('https://httpbin.org/get')
		.then(function mySuccess(response) {
		console.log(response);
		},function myError(response) {        
		 console.log(response);
     });		
		
		// $http({
            // method: 'GET',
            // url: "http://localhost:55185/api/Utilisateurs/",  
			// params: { email: $scope.user.email, password: $scope.user.password }
        // }).then(function mySuccess(response) {
		// console.log(response);
      // $("#display-success").append("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>You Signed up with Success!</strong> You may login now.</div>");
                // $('#login-form-link').trigger( "click" );
				// alert("kjhk");
    // }, function myError(response) {
        // $("#errors-panel").show();		
		// console.log(response);
    // });		
	};
	

   
});