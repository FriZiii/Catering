﻿function getSelectedValuesByIndex(index) {
    const cartItem = cartItems[index];
    return cartItem.selectedValues;
}
function getDates() {
    const calendarWrappers = document.querySelectorAll(".calendar-wrapper");
    const tab = [];
    calendarWrappers.forEach((wrapper, index) => {
        tab.push(getSelectedValuesByIndex(index));
    });
    return tab;
}

function checkOrderItems() {
    var cartItemElements = document.getElementsByClassName("cart-item");
    var selectedDates = getDates();
    for (var i = 0; i < cartItemElements.length; i++) {
        var cartItemElement = cartItemElements[i];
        var caloriesInput = cartItemElement.querySelector("input[name^='cartItems']:checked");
        var mealInputs = cartItemElement.querySelectorAll("input[name^='cartItems'][type='checkbox']:checked");
        var selectedDate = selectedDates[i]

        if (!caloriesInput || mealInputs.length === 0 || selectedDate.length ===0) {
            return false;
        }
    }

    return true;
}

function submitForm() {
    var errorHeading = document.getElementById("error-heading");
    var cartTitle = document.querySelector(".cart-title");

    if (!checkOrderItems()) {
        if (!errorHeading) {
            errorHeading = document.createElement("h3");
            errorHeading.id = "error-heading";
            errorHeading.textContent = "Complete your order setup to proceed!";
            errorHeading.classList.add("valid-message");
            cartTitle.parentNode.insertBefore(errorHeading, cartTitle.nextSibling);
        }
        return;
    } else {
        if (errorHeading) {
            errorHeading.parentNode.removeChild(errorHeading);
        }
    }
    var cartItems = [];
    var cartItemElements = document.getElementsByClassName("cart-item");
    var selectedDates = getDates();

    var inputs = document.querySelectorAll("input[id='productID']");
    var productIDs = [];
    inputs.forEach(function (input) {
        productIDs.push(input.value);
    });

    for (var i = 0; i < cartItemElements.length; i++) {
        var cartItemElement = cartItemElements[i];
        var calories = cartItemElement.querySelector("input[name^='cartItems']:checked").value;
        var meals = [];
        var mealElements = cartItemElement.querySelectorAll("input[name^='cartItems'][type='checkbox']:checked");
        for (var j = 0; j < mealElements.length; j++) {
            meals.push(mealElements[j].value);
        }

        var orderItem = {
            Calories: calories,
            Meals: meals,
            Dates: selectedDates[i],
            ProductId: productIDs[i]
        };

        cartItems.push(orderItem);
    }

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Order/Submit");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onload = function () {
        if (xhr.status === 200) {
            window.location.href = "/Home/Index";
        }
    };

    xhr.send(JSON.stringify(cartItems));
}

document.addEventListener("DOMContentLoaded", function () {
    var checkboxes = document.querySelectorAll('.container_checkbx input[type="radio"]');
    var accordionItems = document.querySelectorAll(".accordion-cart button");
    var selectedDays = [];

    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener("change", function () {
            var selectedCalories = this.nextElementSibling.innerText.trim();
            var accordionTitle = this.closest('.accordion-item-cart').querySelector('.accordion-title-cart');
            var h4Elements = accordionTitle.querySelectorAll('h4');

            h4Elements[1].innerText = selectedCalories + ' kcal';
        });
    });

    accordionItems.forEach(function (item) {
        item.addEventListener('click', toggleAccordion);
    });

    function toggleAccordion() {
        const itemToggle = this.getAttribute('aria-expanded');

        for (i = 0; i < accordionItems.length; i++) {
            accordionItems[i].setAttribute('aria-expanded', 'false');
        }

        if (itemToggle == 'false') {
            this.setAttribute('aria-expanded', 'true');
        }
    }

    function updateThirdH4Value() {
        var accordionTitles = document.querySelectorAll('.accordion-item-cart .accordion-title-cart');
        accordionTitles.forEach(function (accordionTitle, index) {
            var h4Elements = accordionTitle.querySelectorAll('h4');
            h4Elements[2].innerText = selectedDays[index].length + ' Days';

        });
    }

    function updateSelectedDays() {
        selectedDays = getDates();
        updateThirdH4Value();
    }

    selectedDays = getDates();
    updateThirdH4Value();

    setInterval(updateSelectedDays, 500);
});