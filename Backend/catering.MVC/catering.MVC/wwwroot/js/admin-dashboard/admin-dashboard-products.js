//Validation
function clearValidationDiscountSpans() {
    var validationSpans = document.querySelectorAll('#createDiscountForm .error');
    validationSpans.forEach(function (span) {
        span.textContent = '';
    });
}

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

//Delete
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

//Displaying records async
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

function updateRowsProducts() {
    const searchProductInput = document.getElementById('search-product');
    const rowsProducts = document.querySelectorAll('#div4-admin tbody tr');
    const counterProduct = document.querySelector('#div4-admin .search-counter-admin');

    counterProduct.textContent = (document.querySelectorAll('#div4-admin tbody tr')).length;

    searchProductInput.addEventListener('input', function (event) {
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

//Submit form
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
        } else if (xhr.status === 400) {
            var errors = JSON.parse(xhr.responseText);
            Object.keys(errors).forEach(function (key) {
                var validationMessage = errors[key][errors[key].length - 1];

                var validationSpan = document.getElementById(key + '-valid');
                if (validationSpan) {
                    validationSpan.textContent = validationMessage;
                }
            });
        }
    };

    xhr.send(formData);
}

LoadProducts()