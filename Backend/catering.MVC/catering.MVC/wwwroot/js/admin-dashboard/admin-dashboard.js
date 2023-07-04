//Modal
function openModalAdminProduct() {
    document.getElementById("modal-create-product-admin").style.display = "block";
    document.getElementById("header-admin").style.zIndex = -1;
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-product-admin").style.display = "none";
    document.getElementById("header-admin").style.zIndex = 1;
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
    document.getElementById("header-admin").style.zIndex = -1;
}

function closeModalAdminDiscount() {
    document.getElementById("modal-create-discount-admin").style.display = "none";
    document.getElementById("header-admin").style.zIndex = 1;
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

document.addEventListener("DOMContentLoaded", function (event) {
    showDiv(1);
});

function changeIcon(button, imagePath) {
    var img = button.querySelector('.icon img');
    img.src = imagePath;
}

//Filtering
const searchUserInput = document.getElementById('search-user');
const rowsUser = document.querySelectorAll('#div1-admin tbody tr');
const counterUser = document.querySelector('#div1-admin .search-counter-admin');
searchUserInput.addEventListener('keyup', function (event) {
    const q = event.target.value.toLowerCase();
    let count = 0;
    rowsUser.forEach((row) => {
        let matchFound = false;
        const records = row.querySelectorAll('td');
        records.forEach(record => {
            if (record.textContent.toLowerCase().includes(q)) {
                matchFound = true;
            }
        });
        if (matchFound === true) {
            row.style.display = '';
            count += 1;
        } else {
            row.style.display = 'none';
        }
    });
    counterUser.textContent = count;
});


const searchOrderInput = document.getElementById('search-order');
const rowsOrder = document.querySelectorAll('#div3-admin tbody tr');
const counterOrder = document.querySelector('#div3-admin .search-counter-admin');
searchOrderInput.addEventListener('keyup', function (event) {
    const q = event.target.value.toLowerCase();
    let count = 0;
    rowsOrder.forEach((row) => {
        let matchFound = false;
        const records = row.querySelectorAll('td');
        records.forEach(record => {
            if (record.textContent.toLowerCase().includes(q)) {
                matchFound = true;
            }
        });
        if (matchFound === true) {
            row.style.display = '';
            count += 1;
        } else {
            row.style.display = 'none';
        }
    });
    counterOrder.textContent = count;
});