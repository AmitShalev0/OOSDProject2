// JS File for making default elements for each page

function navBar() {
    startTime(); // Start the clock

    function startTime() {
        const today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();
        var d = today.getDate();
        var mts = today.getMonth() + 1;
        var y = today.getFullYear();
        if (m < 10) { m = "0" + m }
        if (s < 10) { s = "0" + s }
        document.getElementById('timeDisplay').innerHTML = h + ":" + m + ":" + s + "<br>" + mts + "." + d + "." + y;
        setTimeout(startTime, 1000);
    }

    //function navBar() {
    //    const navhtml = `
    //        <nav id="navbar" class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
    //        <div class="container-fluid">
    //            <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">TravelExpertsMVC</a>
    //            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" aria-controls="navbarSupportedContent"
    //                    aria-expanded="false" aria-label="Toggle navigation">
    //                <span class="navbar-toggler-icon"></span>
    //            </button>

    //            <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
    //                <ul class="navbar-nav flex-grow-1">
    //                    <li class="nav-item">
    //                        <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Home</a>
    //                    </li>
    //                    <li class="nav-item">
    //                        <a class="nav-link text-dark" asp-area="" asp-controller="Packages" asp-action="AvailablePackages">Packages</a>
    //                    </li>
    //                    <li class="nav-item">
    //                        <a class="nav-link text-dark" asp-area="" asp-controller="Packages" asp-action="MyPackages">My Packages</a>
    //                    </li>
    //                    <li id="timer"><a id="timeDisplay"></a></li>
    //                </ul>
    //                `
    //    document.getElementById("navbar").innerHTML = navhtml;
    //    startTime();
    //}

    function footer() {
        const foothtml = `
        <div class="text-container">
            <ul>
                <li><a href="index">Home Page</a></li>
                <li><a href="login">Login</a></li>
                <li><a href="vacationPackages">Vacation Packages</a></li>
                <li><a href="contact">Contact Us</a></li>
            </ul>
        </div>
        <div class="social-media-icons">
            <a href="#" class="fa fa-facebook"></a>
            <a href="#" class="fa fa-youtube"></a>
            <a href="#" class="fa fa-instagram"></a>
        </div>
        <div class="copyright">
            <img src="transparent_logo.png" alt="Travel experts logo" />
            <p>&copy; 2023 Travel Experts LTD. All rights reserved.</p>
        </div>`
        document.getElementsByClassName("containerFoot")[0].innerHTML = foothtml;
    }
}