// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Get the current page's URL
var currentUrl = window.location.pathname;

// Find the navigation link that matches the current URL path and add the "active" class
$("ul.navbar-nav li.nav-item a").each(function () {
    var linkUrl = $(this).attr("href");

    // Check if the current URL path starts with the link URL or is the exact match
    if (currentUrl === linkUrl || currentUrl.startsWith(linkUrl)) {
        $(this).addClass("active");
    } else {
        $(this).removeClass("active"); // Remove "active" class from other links
    }
});

/*// Get the current page's URL
var currentUrl = window.location.pathname;

// Find the navigation link that matches the current URL path and add the "active" class
$("ul.navbar-nav li.nav-item a").each(function () {
    var linkUrl = $(this).attr("href");

    // Check if the current URL path starts with the link URL or is the exact match
    if (currentUrl === linkUrl) {
        $(this).addClass("active");
    } else {
        $(this).removeClass("active"); // Remove "active" class from other links
    }
});*/





$("#name").on("change", function () {


    if (setValues($('#name')) == null || setValues($('#name')) == NaN) {
        return document.getElementById("vname").innerHTML = "Name  is Required";
    }
    else {
        document.getElementById("vname").innerHTML = "";
    }

});
