//Switchings divs
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
    if (img.getAttribute('src') === '../images/icons/arrow-down/arrow-down.svg') {
        img.setAttribute('src', '../images/icons/arrow-up/arrow-up.svg');
    } else {
        img.setAttribute('src', '../images/icons/arrow-down/arrow-down.svg');
    }
}


document.addEventListener("DOMContentLoaded", function (event) {
    showDiv(1);
    document.getElementById("div2-admin").style.display = "none";
    document.getElementById("div3-admin").style.display = "none";
    document.getElementById("div4-admin").style.display = "none";
});

function changeIcon(button, imagePath) {
    var img = button.querySelector('.icon img');
    img.src = imagePath;
}

function clearInput(inputId) {
    const input = document.getElementById(inputId);
    input.value = '';
    input.dispatchEvent(new Event('input'));
}