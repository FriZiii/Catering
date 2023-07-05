const searchOrderInput = document.getElementById('search-order');
const rowsOrders = document.querySelectorAll('#div3-admin tbody tr');
const counterOrder = document.querySelector('#div3-admin .search-counter-admin');

counterOrder.textContent = (document.querySelectorAll('#order-record')).length;
console.log(document.querySelectorAll('#order-record'));

searchOrderInput.addEventListener('input', function (event) {
    const q = event.target.value.toLowerCase();
    let count = 0;
    rowsOrders.forEach((row) => {
        let matchFound = false;
        const records = row.querySelectorAll('#order-record td');
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
    counterOrder.textContent = count;
});