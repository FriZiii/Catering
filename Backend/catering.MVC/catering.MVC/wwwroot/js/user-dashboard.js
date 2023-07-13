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

const form = document.getElementById('user-panelForm');
const inputs = form.getElementsByTagName('input');
const submitButton = document.getElementById('user-panelSubmit');
submitButton.disabled = true;
const initialValues = Array.from(inputs).map(input => input.value);

Array.from(inputs).forEach((input, index) => {
    input.addEventListener('input', () => {
        const hasChanged = input.value !== initialValues[index];

        submitButton.disabled = !hasChanged;
    });
});

//Validation
function clearValidationUpdateSpans() {
    var validationSpans = document.querySelectorAll('#user-panelForm .error');
    validationSpans.forEach(function (span) {
        span.textContent = '';
    });
}

function submitUpdateDeliveryAdressForm(event) {
    event.preventDefault();

    var form = document.querySelector('#user-panelForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/UserDashboard/UpdateDeliveryAdress', true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                location.reload()
            } else if (xhr.status === 400) {
                var errors = JSON.parse(xhr.responseText);

                clearValidationUpdateSpans();

                Object.keys(errors).forEach(function (key) {
                    var validationMessage = errors[key][errors[key].length - 1];

                    var validationSpan = document.getElementById(key + '-valid');
                    if (validationSpan) {
                        validationSpan.textContent = validationMessage;
                    }
                });
            }
        }
    };

    xhr.send(formData);
}

const searchOrderUserInput = document.getElementById('search-user-order');
const rowsUserOrders = document.querySelectorAll('#div2-user-panel tbody tr');
const counterUserOrder = document.querySelector('#div2-user-panel .search-counter-user-panel');

counterUserOrder.textContent = (document.querySelectorAll('#user-order-record')).length;

searchOrderUserInput.addEventListener('input', function (event) {
    const q = event.target.value.toLowerCase();
    let count = 0;
    rowsUserOrders.forEach((row) => {
        let matchFound = false;
        const records = row.querySelectorAll('#user-order-record td');
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
    counterUserOrder.textContent = count;
});