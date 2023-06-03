const modal_container = document.getElementById('offer-modal-container');
const openModal = document.getElementById('open-modal-button');
const closeModal = document.getElementById('add-to-cart-button');

openModal.addEventListener('click', () => {
    modal_container.classList.add('show');
});

closeModal.addEventListener('click', () => {
    modal_container.classList.remove('show');
});