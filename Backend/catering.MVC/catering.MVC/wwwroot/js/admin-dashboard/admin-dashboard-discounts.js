//Validation
function clearValidationDiscountSpans() {
    var validationSpans = document.querySelectorAll('#createDiscountForm .error');
    validationSpans.forEach(function (span) {
        span.textContent = '';
    });
}

//Modal
function openModalAdminDiscount() {
    document.getElementById("modal-create-discount-admin").style.display = "block";
    var form = document.querySelector('#createDiscountForm');
    clearValidationDiscountSpans();
    form.reset();
}

function closeModalAdminDiscount() {
    document.getElementById("modal-create-discount-admin").style.display = "none";
}

const DeleteDiscountById = (id) => {
    $.ajax({
        url: '/DiscountCode/DeleteById',
        type: 'DELETE',
        data: {
            'id': id
        },
        success: function () {
            LoadDiscounts()
        }
    })
}

//Displaying records async
const RenderDiscounts = (discounts, discountContainer) => {
    discountContainer.empty();
    for (const discount of discounts) {
        var formattedDate = (discount.expiration).split("T")[0];
        discountContainer.append(`
        <tr>
            <td>${discount.id}</td>
            <td>${discount.code}</td>
            <td>${discount.discountPercentage}</td>
            <td>${formattedDate}</td>
            <td>
                <button class="delete-button-admin" onclick="DeleteDiscountById(${discount.id})">
                    <img src="../images/icons/close/close.svg">
                    Delete
                </button>
            </td>
        </tr>
        `)
    }
}

const LoadDiscounts = () => {
    const discountContainer = $("#div2-admin tbody");

    $.ajax({
        url: '/DiscountCode/GetAll',
        type: 'get',
        success: function (data) {
            RenderDiscounts(data, discountContainer);
            updateRowsDiscount();
        }
    })
}

function updateRowsDiscount() {
    const searchDiscountInput = document.getElementById('search-discount');
    const rowsDiscount = document.querySelectorAll('#div2-admin tbody tr');
    const counterDiscount = document.querySelector('#div2-admin .search-counter-admin');

    counterDiscount.textContent = (document.querySelectorAll('#div2-admin tbody tr')).length;

    searchDiscountInput.addEventListener('input', function (event) {
        const q = event.target.value.toLowerCase();
        let count = 0;
        rowsDiscount.forEach((row) => {
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
        counterDiscount.textContent = count;
    });
}

//Submit form
function submitDiscountForm(event) {
    event.preventDefault();

    var form = document.querySelector('#createDiscountForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/DiscountCode/Create', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                LoadDiscounts();
                form.reset();
                closeModalAdminDiscount();
            } else if (xhr.status === 400) {
                var errors = JSON.parse(xhr.responseText);

                clearValidationDiscountSpans();

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

LoadDiscounts()