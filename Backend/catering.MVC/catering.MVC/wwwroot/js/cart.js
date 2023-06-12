function getSelectedValuesByIndex(index) {
    const cartItem = cartItems[index];
    return cartItem.selectedValues;
}

function getDates() {
    const calendarWrappers = document.querySelectorAll(".calendar-wrapper");
    const tab = [];
    calendarWrappers.forEach((wrapper, index) => {
        tab.push(getSelectedValuesByIndex(index));
    });
    return tab; // Zwracanie wartości tablicy
}

document.getElementById("myForm").addEventListener("submit", function (event) {
    event.preventDefault(); // Zapobieganie domyślnemu zachowaniu przesyłania formularza

    const tab = getDates(); // Przechwycenie wartości zwracanej przez funkcję getDates()

    // Aktualizowanie wartości pola ukrytego
    document.getElementById("dates").value = JSON.stringify(tab);

    // Przesłanie formularza
    this.submit();
});