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
        <tr>
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

function submitDiscountForm(event) {
    event.preventDefault();

    var form = document.querySelector('#createDiscountForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/DiscountCode/Create', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            LoadProducts();
            form.reset();
            closeModalAdminDiscount();
        }
    };

    xhr.send(formData);
}


function updateRowsDiscount() {
    const searchDiscountInput = document.getElementById('search-discount');
    const rowsDiscount = document.querySelectorAll('#div2-admin tbody tr');
    const counterDiscount = document.querySelector('#div2-admin .search-counter-admin');
    searchDiscountInput.addEventListener('keyup', function (event) {
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

LoadDiscounts()