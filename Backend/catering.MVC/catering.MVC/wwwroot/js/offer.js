const modal_container = document.getElementById('offer-modal-container');
const openModal = document.getElementById('open-modal-button');
const closeModal = document.getElementById('close-modal-button');
const footer = document.getElementById('footer-offer');
const productCards = document.querySelectorAll('.product-card-offer');
const menu = document.getElementById('header-offer');
const logo = document.getElementById('offer-logo');
const contentOffer = document.querySelector('.content-offer');
isOffer = false;

productCards.forEach((productCard, index) => {
    const modal_container = document.getElementById(`offer-modal-container-${index}`);
    const closeModal = document.getElementById(`close-modal-button-${index}`);

    productCard.addEventListener('click', () => {
        const productName = productCard.querySelector('.product-name-offer').textContent;
        const productPrice = productCard.querySelector('.product-price-offer').textContent;
        modal_container.classList.add('show');
        footer.style.opacity = '0';
        menu.style.opacity = '0';
        console.log(`Product "${productName}" with price ${productPrice} clicked!`);
        isOffer = true;
    });

    closeModal.addEventListener('click', () => {
        logo.style.opacity = '1';
        modal_container.classList.remove('show');
        menu.style.opacity = '1';
        footer.style.opacity = '1';
        isOffer = false;
    });
});
