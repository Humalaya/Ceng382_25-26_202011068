const loginAttempts = [];

document.addEventListener("DOMContentLoaded", function () {
    const loginForm = document.getElementById("loginForm");
    const loginButton = document.getElementById("loginButton");
    const usernameInput = document.getElementById("username");
    const passwordInput = document.getElementById("password");
    const clockElement = document.getElementById("clock");

    function updateClock() {
        const now = new Date();
        const timeString = now.toLocaleTimeString();
        clockElement.textContent = timeString;
    }
    setInterval(updateClock, 1000);
    updateClock();

    loginButton.addEventListener("click", function (event) {
        event.preventDefault();
        const loginData = {
            username: usernameInput.value,
            password: passwordInput.value,
            timestamp: new Date().toLocaleString()
        };
        loginAttempts.push(loginData);
        console.log("Login Attempts:", loginAttempts);
        if(usernameInput.value == "admin" && passwordInput.value == "admin"){
            window.location.href = "table.html";
        }
        usernameInput.value = "";
        passwordInput.value = "";

        alert("Login attempt recorded!");
    });

    document.addEventListener("keydown", function (event) {
        if (event.key.toLowerCase() === "h" && !document.activeElement.matches("input, textarea")) {
            loginForm.style.display = loginForm.style.display === "none" ? "block" : "none";
        }
    });
});
