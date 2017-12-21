$(function () {
		
    //Login submit button click
    $('#signout').click(function (e) {		
        $(".panel").fadeIn(100);
		$("#signout").fadeOut(100);
		$("#display-success").append("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>You're Signed out!</strong> </div>");
        e.preventDefault();
    });	 //Login submit button click
    $('#login-submit').click(function (e) {
        var email = $('#login-email').val();
        var password = $('#login-password').val();
        signin(email, password);
        e.preventDefault();
    });	
    //Register now submit button click
    $('#register-submit').click(function (e) {
        var firstName = $('#firstname').val();
        var lastName = $('#lastname').val();
        var email = $('#email').val();
        var password = $('#password').val();
        var passwordConfirm = $('#confirm-password').val();

        if (validateSignupForm(firstName, lastName, email, password, passwordConfirm)) {
            var signupStaus = signup(firstName, lastName, email, password, password);
            if (signupStaus != -1) {
			$("#display-success").append("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>You Signed up with Success!</strong> You may login now.</div>");
                $('#login-form-link').trigger( "click" );
            }
        } else {            
			$("#errors-panel").show();
        }        
        e.preventDefault();
    });
	
	//forgot password submit button click
    $('#forgot-submit').click(function (e) {
        var email = $('#forgot-email').val();        
        sendPassword(email);		
        e.preventDefault();
    });
	
    //Switch to Login 
    $('#login-form-link').click(function (e) {
        $("#login-form").delay(100).fadeIn(100);
        $("#register-form").fadeOut(100);
		$("#forgot-form").fadeOut(100);
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
	
    //Switch to Register 
    $('#register-form-link').click(function (e) {
        $("#register-form").delay(100).fadeIn(100);
        $("#login-form").fadeOut(100);
		$("#forgot-form").fadeOut(100);
        $('#login-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
	//Switch to forgot password
    $('#forgot-password-link').click(function (e) {
	$("#register-form").fadeOut(100);
	$("#login-form").fadeOut(100);
	$("#forgot-form").fadeIn(100);
	e.preventDefault();
	});

});

var apiUrl="http://localhost:55185/";

//utilisant ajax pour appeller la methode GET signin du WebAPI pour  l'identification ;
function signin(email, password) {
    $.ajax({
        type: "GET",
        url: apiUrl+"api/Utilisateurs/",
        data: { email: email, password: password },
        success: function (response) {		
            $(".panel").fadeOut(100);
            $(".row").html("<div class='jumbotron' style='text-align: center'><h1>Hello " +
                response.first_name + " " + response.last_name + "</h1 ></div >");
            $("#signout").fadeIn(100);
        },
        error: function (response) {
            alert(response.Message);
            console.log(response);
        }
    });
}

//creer un nouveau utilisateur , utilisant ajax pour appeller la methode POST signup du WebAPI
function signup(firstName, lastName, email, password) {
    $.ajax({
        type: "POST",
        url: apiUrl+"api/Utilisateurs/",
        data: { first_name: firstName, last_name: lastName, email: email, password: password },
        success: function (response) {
            return 1;

        },
        error: function (response) {
            alert(response.Message);
            console.log(response);
            return -1;
        }
    });
}

//valider le formulaire "signup"
function validateSignupForm(firstName, lastName, email, password, confirmPassword) {
    if (firstName == "") return false;
    if (lastName == "") return false;
    if (email == "") return false;
    if (password == "") return false;
    if (confirmPassword == "") return false;
    if (password != confirmPassword) return false;
    return true;

}
function sendPassword(email){
    $.ajax({
        type: "GET",
        url: apiUrl+"api/Utilisateurs/",
        data: { email: email},
        success: function (response) {
            $("#display-success").html("<div class='alert alert-success alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>An email sent to your address with password!</strong> You may check your Inbox or Spam folder now.</div>");		
			console.log(response);
        },
        error: function (response) {            
		$("#display-success").html("<div class='alert alert-danger alert-dismissable' ><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>Error!</strong> This Email doesn't existe.</div>");
            console.log(response);            
        }
    });
}


