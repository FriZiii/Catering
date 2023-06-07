const openModal = document.getElementById('open-modal-button');
const footer = document.getElementById('footer-offer');
const productCards = document.querySelectorAll('.product-card-offer');
const logIn = document.getElementById('offer-login');
const logo = document.getElementById('offer-logo');
const contentOffer = document.querySelector('.content-offer');
isOffer = false;



productCards.forEach((productCard, index) => {
    const modal_container = document.getElementById(`offer-modal-container-${index}`);
    const closeModal = document.getElementById(`close-modal-button-${index}`);

    productCard.addEventListener('click', () => {
        modal_container.classList.add('show');
        footer.style.opacity = '0.3';
        logIn.style.opacity = '0.45';
        logo.style.opacity = '0.45';
        isOffer = true;
    });

    closeModal.addEventListener('click', () => {
        logo.style.opacity = '1';
        modal_container.classList.remove('show');
        logIn.style.opacity = '1';
        footer.style.opacity = '1';
        isOffer = false;
    });
});