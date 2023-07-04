const DeleteProductById = (id) => { 
    $.ajax({
        url: '/Offer/DeleteProductById',
        type: 'DELETE',
        data: {
            'id': id
        },
        success: function () {
            LoadProducts()
        }
    })
}


const RenderProducts = (products, productsContainer) => {
    productsContainer.empty();

    for (const product of products) {
        productsContainer.append(`
        <tr>
            <td>${product.id}</td>
            <td>${product.name}</td>
            <td>${product.description}</td>
            <td>${product.price}$</td>
            <td>${product.imageName}</td>
            <td>
                <button class="delete-button-admin" onclick="DeleteProductById(${product.id})">
                    <img src="../images/icons/close/close.svg">
                    Delete
                </button>
            </td>
        </tr>
        `)
    }
}


const LoadProducts = () => {
    const productsContainer = $("#div4-admin tbody");

    $.ajax({
        url: '/Offer/GetProducts',
        type: 'get',
        success: function (data) {
            RenderProducts(data, productsContainer);
            updateRowsProducts();
        }
    })
}


function submitProductForm(event) {
    event.preventDefault();

    var form = document.querySelector('#createProductForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Offer/CreateProduct', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            LoadProducts();
            form.reset();
            closeModalAdminProduct();
        }
    };

    xhr.send(formData);
}

function updateRowsProducts() {
    const searchProductInput = document.getElementById('search-product');
    const rowsProducts = document.querySelectorAll('#div4-admin tbody tr');
    const counterProduct = document.querySelector('#div4-admin .search-counter-admin');

    counterProduct.textContent = (document.querySelectorAll('#div4-admin tbody tr')).length;

    searchProductInput.addEventListener('keyup', function (event) {
        const q = event.target.value.toLowerCase();
        let count = 0;
        rowsProducts.forEach((row) => {
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
        counterProduct.textContent = count;
    });
}


LoadProducts()