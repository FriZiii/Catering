function submitDiscountForm(event) {
    event.preventDefault();

    var form = document.querySelector('#createDiscountForm');
    var formData = new FormData(form);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/DiscountCode/Create', true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            LoadProducts();
            closeModalAdminDiscount();
        }
    };

    xhr.send(formData);
}