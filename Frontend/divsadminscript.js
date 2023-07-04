var currentDiv = null;

function showDiv(divNumber) {
    if (currentDiv !== null) {
        currentDiv.style.display = "none";
    }

    var div = document.getElementById("div" + divNumber + "-admin");
    div.style.display = "flex";
    currentDiv = div;
}

function toggleOrderDetails(button) {
    var orderDetailsRow = button.closest('tr').nextElementSibling;
    orderDetailsRow.classList.toggle('order-details-admin');
    var img = button.querySelector('img');
    if (img.getAttribute('src') === 'Images/arrow-down.svg') {
        img.setAttribute('src', 'Images/left-arrow.svg');
    } else {
        img.setAttribute('src', 'Images/arrow-down.svg');
    }
}

document.addEventListener("DOMContentLoaded", function(event) {
    showDiv(1);
    document.getElementById("div2-admin").style.display = "none";
    document.getElementById("div3-admin").style.display = "none";
    document.getElementById("div4-admin").style.display = "none";
});

function changeIcon(button, imagePath) {
    var img = button.querySelector('.icon img');
    img.src = imagePath;
  }