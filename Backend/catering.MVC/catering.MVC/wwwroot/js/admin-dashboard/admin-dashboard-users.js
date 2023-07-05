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
            <td>${user.normalizedEmail}</td>
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
        </tr>
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
            updateRowsUsers();
        }
    })
}

function updateRowsUsers() {
    const searchUserInput = document.getElementById('search-user');
    const rowsUser = document.querySelectorAll('#div1-admin tbody tr');
    const counterUser = document.querySelector('#div1-admin .search-counter-admin');

    counterUser.textContent = (document.querySelectorAll('#div1-admin tbody tr')).length;

    searchUserInput.addEventListener('input', function (event) {
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
}


LoadUsers()