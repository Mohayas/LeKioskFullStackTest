var app = angular.module("kioskApp", []);

app.controller("utilisateurController", function($scope,$http) {
    $scope.user = {firstName:"mememe",lastName:"aaa",email:"aa@aa",password:"pop",confirmPassword:"pop"};
	//signin
     $scope.signin = function() {   
		$http({
            method: 'GET',
            url: "http://localhost:55185/api/Utilisateurs/",  
			params: { email: $scope.user.email, password: $scope.user.password }
        }).success(function(data){
             $(".panel").fadeOut(100);
            $(".row").html("<div class='jumbotron' style='text-align: center'><h1>Hello " +
                $scope.user.firstName + " " + $scope.user.Name + "</h1 ></div >");
            $("#signout").fadeIn(100);
        }).error(function(){
            $("#display-success").html("<div class='alert alert-danger alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> This email password combination incorrect .</div>");
            console.log(response);            
        });	    
	};
	//signup
   $scope.signup = function() {      
    $http.post({        	
         url : "http://localhost:55185/api/Utilisateurs/",         
		params: { first_name: $scope.user.firstName, last_name: $scope.user.lastName, email: $scope.user.email, password: $scope.user.password }		
    }).then(function mySuccess(response) {
				$("#display-success").append("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>You Signed up with Success!</strong> You may login now.</div>");
                $('#login-form-link').trigger( "click" );
    }, function myError(response) {
        $("#errors-panel").show();		
		console.log(response);
    });		
	};   
	//forgot password
	$scope.signuo = function() {      
    $http.get({        	
         url : "http://localhost:55185/api/Utilisateurs/",         
		params: { email: $scope.user.email}		
    }).then(function mySuccess(response) {
       $("#display-success").html("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>An email sent to your address with password!</strong> You may check your Inbox or Spam folder now.</div>");		
			console.log(response);
    }, function myError(response) {
       $("#display-success").html("<div class='alert alert-danger alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> This Email doesn't existe.</div>");        
		console.log(response);
    });		
	};

   
});