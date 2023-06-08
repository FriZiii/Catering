// Get the hamburger button and mobile menu elements
    const hamburgerButton = document.querySelector('.hamburger');
    const mobileMenu = document.querySelector('.mobile-menu');

    // Add click event listener to the hamburger button
    hamburgerButton.addEventListener('click', function() {
        // Toggle the 'active' class on the mobile menu
        mobileMenu.classList.toggle('is-open');
    });