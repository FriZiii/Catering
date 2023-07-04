var currentDiv = null;

function showDiv(divNumber) {
    if (currentDiv !== null) {
        currentDiv.style.display = "none";
    }

    var div = document.getElementById("div" + divNumber + "-user-panel");
    div.style.display = "flex";
    currentDiv = div;
}

function toggleOrderDetails(button) {
    var orderDetailsRow = button.closest('tr').nextElementSibling;
    orderDetailsRow.classList.toggle('order-details');
}

document.addEventListener("DOMContentLoaded", function(event) {
    showDiv(1);
});

function changeIcon(button, imagePath) {
    var img = button.querySelector('.icon img');
    img.src = imagePath;
  }