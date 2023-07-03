//Modal
function openModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "block";
    document.getElementById("header-admin").style.zIndex = -1;
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "none";
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
const searchProductInput = document.getElementById('search-product');
const rows = document.querySelectorAll('tbody tr');
const counter = document.getElementsByClassName('search-counter-admin')[0];

searchProductInput.addEventListener('keyup', function (event) {
    const q = event.target.value.toLowerCase();
    let count = 0;
    rows.forEach((row) => {
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
    counter.textContent = count;
});