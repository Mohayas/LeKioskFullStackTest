$(function () {

	
		
    //Login button click
    $('#login-submit').click(function (e) {
        var email = $('#login-email').val();
        var password = $('#login-password').val();
        signin(email, password);
        e.preventDefault();
    });

    //Register now button click
    $('#register-submit').click(function (e) {
        var firstName = $('#firstname').val();
        var lastName = $('#lastname').val();
        var email = $('#email').val();
        var password = $('#password').val();
        var passwordConfirm = $('#confirm-password').val();

        if (validateSignupForm(firstName, lastName, email, password, passwordConfirm)) {
            var signupStaus = signup(firstName, lastName, email, password, password);
            if (signupStaus != -1) {
                signin(email, password);
            }
        } else {
            alert("NOT valide!");
        }
        //signin(email, password);
        e.preventDefault();
    });

    $("#signout").fadeOut(100);
    //Switch to Login 
    $('#login-form-link').click(function (e) {
        $("#login-form").delay(100).fadeIn(100);
        $("#register-form").fadeOut(100);
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    //Switch to Register 
    $('#register-form-link').click(function (e) {
        $("#register-form").delay(100).fadeIn(100);
        $("#login-form").fadeOut(100);
        $('#login-form-link').removeClass('active');
        $(this).addClass('active');
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
		alert("ssss"+response);
            $(".panel").fadeOut(100);
            $(".row").append("<div class='jumbotron' style='text-align: center'><h1>Hello " +
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


