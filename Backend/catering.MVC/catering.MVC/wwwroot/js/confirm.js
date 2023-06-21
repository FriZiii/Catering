const openModalButton = document.getElementById('order-open-modal');
const closeModalButton = document.getElementById('order-close-modal');
const modalContainer = document.getElementById('order-modal-container');
console.log('XD');
openModalButton.addEventListener('click', () => {
    modalContainer.classList.add('show');
    footer.style.opacity = '0';

});

closeModalButton.addEventListener('click', () => {
    modalContainer.classList.remove('show');
    footer.style.opacity = '1';
});
