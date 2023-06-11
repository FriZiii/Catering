const cartItems = [];

const months = [
    "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
];

function renderCalendar(index, currentDate) {
    const currentDateElement = document.querySelector(`#calendar-wrapper-${index} .current-date`);
    const daysTag = document.querySelector(`#calendar-wrapper-${index} .days`);
    const cartItem = cartItems[index];

    if (currentDateElement && daysTag) {
        const currYear = currentDate.getFullYear();
        const currMonth = currentDate.getMonth();
        const firstDayOfMonth = new Date(currYear, currMonth, 1).getDay();
        const lastDateOfMonth = new Date(currYear, currMonth + 1, 0).getDate();
        const lastDayOfMonth = new Date(currYear, currMonth, lastDateOfMonth).getDay();
        const lastDateOfLastMonth = new Date(currYear, currMonth, 0).getDate();

        let buttonTag = "";

        for (let i = firstDayOfMonth; i > 0; i--) {
            const date = lastDateOfLastMonth - i + 1;
            const isChecked = cartItem.selectedValues.includes(date) ? "checked" : "";
            buttonTag += `<div class="previusMonthDay">
          <label class="inactive">
              <input type="checkbox" name="" ${isChecked}>
              <span>${date}</span>
          </label>
      </div>`;
        }

        for (let i = 1; i <= lastDateOfMonth; i++) {
            const isToday = i === currentDate.getDate() && currMonth === new Date().getMonth() && currYear === new Date().getFullYear() ? "active" : "";
            const rightMonth = currMonth + 1;
            const currentDay = `${i}/${rightMonth}/${currYear}`;
            const isInactive = i <= currentDate.getDate() && currMonth === new Date().getMonth() ? "inactive" : "";
            const isChecked = cartItem.selectedValues.includes(currentDay) ? "checked" : "";
            buttonTag += `<div class="currentMonthDay">
          <label class="${isToday} ${isInactive}">
              <input type="checkbox" name="dayCheckBox" value="${currentDay}" ${isChecked}>
              <span>${i}</span>
          </label>
      </div>`;
        }

        for (let i = lastDayOfMonth; i < 6; i++) {
            buttonTag += `<div class="nextMonthDay">
          <label class="inactive">
              <input type="checkbox" name="">
              <span>${i - lastDayOfMonth + 1}</span>
          </label>
      </div>`;
        }

        currentDateElement.textContent = `${months[currMonth]} ${currYear}`;
        daysTag.innerHTML = buttonTag;

        const checkboxes = daysTag.querySelectorAll('input[type="checkbox"][name="dayCheckBox"]');

        checkboxes.forEach(function (checkbox) {
            checkbox.addEventListener("click", function () {
                const value = this.value;

                if (this.checked && !cartItem.selectedValues.includes(value)) {
                    cartItem.selectedValues.push(value);
                } else {
                    const index = cartItem.selectedValues.indexOf(value);
                    if (index !== -1) {
                        cartItem.selectedValues.splice(index, 1);
                    }
                }

                console.log(cartItem.selectedValues);
            });
        });
    }
}

function setPreviousOrNextMonth(index, icon) {
    const calendarWrapper = document.getElementById(`calendar-wrapper-${index}`);
    const currentDateElement = calendarWrapper.querySelector(".current-date");

    let currentDate = new Date(currentDateElement.textContent);
    let currYear = currentDate.getFullYear();
    let currMonth = currentDate.getMonth();

    currMonth = icon.classList.contains("prev") ? currMonth - 1 : currMonth + 1;

    if (currMonth < 0) {
        currMonth = 11;
        currYear--;
    } else if (currMonth > 11) {
        currMonth = 0;
        currYear++;
    }

    currentDate = new Date(currYear, currMonth, 1);
    currentDateElement.textContent = `${months[currMonth]} ${currYear}`;

    renderCalendar(index, currentDate);
}

document.addEventListener("DOMContentLoaded", function () {
    const calendarWrappers = document.querySelectorAll(".calendar-wrapper");

    calendarWrappers.forEach((wrapper, index) => {
        const cartItem = { selectedValues: [] };
        cartItems.push(cartItem);

        renderCalendar(index, new Date(), cartItem);

        const prevNextIcons = wrapper.querySelectorAll(".icons span");

        prevNextIcons.forEach((icon) => {
            icon.addEventListener("click", function () {
                setPreviousOrNextMonth(index, this);
            });
        });
    });
});