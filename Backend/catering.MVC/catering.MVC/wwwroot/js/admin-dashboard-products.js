const DeleteProductById = (id) => { 
    console.log(id);
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

const RenderProducts = (products, container) => {
    container.empty();

    for (const product of products) {
        container.append(`
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
        <tr>
        `)
    }
}

const LoadProducts = () => {
    const container = $("#div4-admin tbody");

    $.ajax({
        url: '/Offer/GetProducts',
        type: 'get',
        success: function (data) {
            RenderProducts(data, container);
        }
    })
}

LoadProducts()

function submitProductForm(event) {
    event.preventDefault();

    var form = document.querySelector('#createProductForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Offer/CreateProduct', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            LoadProducts();
            closeModalAdminProduct();
        }
    };

    xhr.send(formData);
}