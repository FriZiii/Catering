    const hamburgerButton = document.querySelector('.hamburger');
    const mobileMenu = document.querySelector('.mobile-menu');
    const closeIcon = document.querySelector('.close-icon.hamburger');

    hamburgerButton.addEventListener('click', function() {
        mobileMenu.classList.toggle('is-open');
    });

    closeIcon.addEventListener('click', function() {
        mobileMenu.classList.toggle('is-open');
    });