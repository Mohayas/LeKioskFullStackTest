$(function () {
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