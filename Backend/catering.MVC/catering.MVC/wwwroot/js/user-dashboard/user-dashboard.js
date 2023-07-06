var currentUserDiv = null;

function showDivUser(divNumber) {
    if (currentUserDiv !== null) {
        currentUserDiv.style.display = "none";
    }

    var div = document.getElementById("div" + divNumber + "-user-panel");
    div.style.display = "flex";
    currentUserDiv = div;
}

function toggleOrderDetailsUser(button) {
    var orderDetailsRow = button.closest('tr').nextElementSibling;
    orderDetailsRow.classList.toggle('order-details');

    var img = button.querySelector('img');
    if (img.getAttribute('src') === '../images/icons/arrow-down/arrow-down.svg') {
        img.setAttribute('src', '../images/icons/arrow-up/arrow-up.svg');
    } else {
        img.setAttribute('src', '../images/icons/arrow-down/arrow-down.svg');
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    showDivUser(1);
});

function changeIconUser(button, imagePath) {
    var img = button.querySelector('.icon img');
    img.src = imagePath;
}