// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    $('.carousel').carousel({        
        interval: 2000
    });
});

function addToCart(ProdId) {
    alert(ProdId);
    $.ajax({
        type: "GET",
        Url:  '@Url.Action("AddToCart", "Dashboard")',
        data: { "ProductId":ProdId },
        success: function(response){
            alert(response)
        }
    });
}