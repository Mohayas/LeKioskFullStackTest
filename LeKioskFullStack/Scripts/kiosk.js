$(function () {
    

    $('#login-submit').click(function (e) {
        var emailVal = $('#login-email').val();
        var passwordVal = $('#login-password').val();
        $.ajax({
            type: "GET",
            url: "api/Utilisateurs/",
            data: { email: emailVal, password: passwordVal },
            dataType: "json",
            success: function (response) {  
                window.location.replace("/Help");
            },
            error: function (response) {
                alert(response.Message);
                console.log(response);                
            }
        });
        e.preventDefault();
    });

    $('#login-form-link').click(function (e) {
        $("#login-form").delay(100).fadeIn(100);
        $("#register-form").fadeOut(100);
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });
    $('#register-form-link').click(function (e) {
        $("#register-form").delay(100).fadeIn(100);
        $("#login-form").fadeOut(100);
        $('#login-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

});