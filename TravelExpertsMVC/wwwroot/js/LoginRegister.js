// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



// this function is onclick, and you click on the eyeCon (the icons).
function togglePasswordVisibility(pasword) {           
    var passwordInput = document.getElementById("password");

    if (passwordInput.type === "password") {    // If the type = password:
        passwordInput.type = "text";            // make type = text
        eyeCon.innerHTML = "Hide Password &#128584";          // change the icon to monkey closing its eyes.
    }
    else {                                      // If the type != password (when type = text):
        passwordInput.type = "password";        // make type = password
        eyeCon.innerHTML = "Show Password &#128064";          // change the icon to eyes.
    }
}


var eyeCon = document.getElementById("eyeCon"); // this completes the function.
eyeCon.addEventListener('click', togglePasswordVisibility); // Listen to when the icon is clicked, then make the togglePassword function work.


// make the same but for the Username:

function toggleUserVisibility(custUserName) {
    var passwordInput = document.getElementById("custUserName");

    if (passwordInput.type === "password") {    // If the type = password:
        passwordInput.type = "text";            // make type = text
        eyeConUser.innerHTML = "Hide Username &#128584";          // change the icon to monkey closing its eyes.
    }
    else {                                      // If the type != password (when type = text):
        passwordInput.type = "password";        // make type = password
        eyeConUser.innerHTML = "Show Username &#128064";          // change the icon to eyes.
    }
}


var eyeConUser = document.getElementById("eyeConUser"); // this completes the function.
eyeConUser.addEventListener('click', toggleUserVisibility); // Listen to when the icon is clicked, then make the togglePassword function work.


function toggleConfirmPasswordVisibility(custConfirmPassword) {
    var passwordInput = document.getElementById("custConfirmPassword");

    if (passwordInput.type === "password") {    // If the type = password:
        passwordInput.type = "text";            // make type = text
        eyeConConfirm.innerHTML = "Hide Password &#128584";          // change the icon to monkey closing its eyes.
    }
    else {                                      // If the type != password (when type = text):
        passwordInput.type = "password";        // make type = password
        eyeConConfirm.innerHTML = "Show Password &#128064";          // change the icon to eyes.
    }
}

var eyeConConfirm = document.getElementById("eyeConConfirm"); // this completes the function.
eyeConConfirm.addEventListener('click', toggleConfirmPasswordVisibility); // Listen to when the icon is clicked, then make the togglePassword function work.