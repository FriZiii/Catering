const hamburger = document.querySelector('.hamburger');
const hamburger_icon = hamburger.querySelector('.material-icons');
const mobile_menu = document.querySelector('.mobile-menu');

hamburger.addEventListener('click', () => {
	hamburger_icon.innerText = hamburger_icon.innerText === 'menu' ? 'close' : 'menu';
	console.log("elo")
	mobile_menu.classList.toggle('is-open');
})