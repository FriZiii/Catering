const Paid = () => {
    $.ajax({
        url: '/Payment/Paid',
        type: 'Post',
        success: function () {
            window.location.href = '/';
        }
    })
}

const button = document.getElementsByClassName('payment-btn-with-icon')[0];
button.addEventListener('click', Paid);