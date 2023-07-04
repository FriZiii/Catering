//Modal
function openModalAdminProduct() {
    document.getElementById("modal-create-product-admin").style.display = "block";
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-product-admin").style.display = "none";
    document.querySelector('.file-name').textContent = "";
    var form = document.querySelector('#createProductForm');
    form.reset();
}

const file = document.querySelector('#file');
file.addEventListener('change', (e) => {
    const [file] = e.target.files;
    const { name: fileName, size } = file;
    const fileSize = (size / 1000).toFixed(2);
    const fileNameAndSize = `${fileName} - ${fileSize}KB`;
    document.querySelector('.file-name').textContent = fileNameAndSize;
});

function openModalAdminDiscount() {
    document.getElementById("modal-create-discount-admin").style.display = "block";
    var form = document.querySelector('#createDiscountForm');
    form.reset();
}

function closeModalAdminDiscount() {
    document.getElementById("modal-create-discount-admin").style.display = "none";
}

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