const DeleteUserById = (id) => {
    $.ajax({
        url: '/User/DeleteById',
        type: 'DELETE',
        data: {
            'id': id
        },
        success: function () {
            LoadUsers()
        }
    })
}

const RenderUsers = (users, usersContainer) => {
    usersContainer.empty();

    for (const user of users) {
        usersContainer.append(`
        <tr>
            <td>${user.id}</td>
            <td>${user.Email}</td>
            <td>${user.firstName}</td>
            <td>${user.lastName}</td>
            <td>${user.deliveryAdress.phoneNumber}</td>
            <td>${user.deliveryAdress.adress1}</td>
            <td>${user.deliveryAdress.adress2}</td>
            <td>${user.deliveryAdress.state}</td>
            <td>${user.deliveryAdress.postalCode}</td>
            <td>${user.deliveryAdress.country}</td>
            <td>
                <button class="delete-button-admin" onclick="DeleteUserById('${user.id}')">
                    <img src="../images/icons/close/close.svg">
                    Delete
                </button>
            </td>
        <tr>
        `)
    }
}

const LoadUsers = () => {
    const usersContainer = $("#div1-admin tbody");

    $.ajax({
        url: '/User/GetAll',
        type: 'get',
        success: function (data) {
            RenderUsers(data, usersContainer);
        }
    })
}

LoadUsers()