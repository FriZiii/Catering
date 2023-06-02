const currentDate = document.querySelector(".current-date"),
daysTag = document.querySelector(".days"),
prevNextIcon = document.querySelectorAll(".icons span");



// getting new date, current year and month
let date = new Date(),
currYear = date.getFullYear(),
currMonth = date.getMonth(),
realMonth = date.getMonth();

const months = ["January", "February", "March", "April", "May", "June", "July",
              "August", "September", "October", "November", "December"];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(), // getting first day of month
    lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(), // getting last date of month
    lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(), // getting last day of month
    lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // getting last date of previous month
    let buttonTag = "";

    for (let i = firstDayofMonth; i > 0; i--) { // adding previous month last days
        buttonTag += `<div>
                    <label class="inactive">
                        <input type="checkbox" name="">
                        <span>${lastDateofLastMonth - i + 1}</span>
                    </label>
                </div>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) { // adding moth days
        let isToday = i === date.getDate() && currMonth === new Date().getMonth() 
                     && currYear === new Date().getFullYear() ? "active" : "";
        let rightMonth = currMonth+1;
        let currentday = i + ' ' + rightMonth + ' ' + currYear;
        buttonTag += `<div id="MyForm">
                     <label class="${isToday}">
                         <input type="checkbox" name="myCheckbox" value="${currentday}">
                         <span>${i}</span>
                     </label>
                 </div>`;
    }

    for (let i = lastDayofMonth; i < 6; i++) { // adding next month first days
        buttonTag += `<div>
                    <label class="inactive">
                        <input type="checkbox" name="">
                        <span>${i - lastDayofMonth + 1}</span>
                    </label>
                </div>`;
    }
    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    daysTag.innerHTML = buttonTag;
}
renderCalendar();

//Next Previous month buttons

 
prevNextIcon.forEach(icon => {
    icon.addEventListener("click", () => {  
        if (currMonth != realMonth){ 
            currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

            if(currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
                // creating a new date of current year & month and pass it as date value
                date = new Date(currYear, currMonth, new Date().getDate());
                currYear = date.getFullYear(); // updating current year with new date year
                currMonth = date.getMonth(); // updating current month with new date month
            } else {
                date = new Date(); // pass the current date as date value
            }
        }
        else{
            currMonth = icon.id=== "prev" ? currMonth : currMonth + 1; 
        }

        renderCalendar();
    });
});


// function getSelectedOptions() {
//     var form = document.getElementById("myForm");
//     var checkboxes = form.querySelectorAll('input[type="checkbox"]:checked');
//     var selectedOptions = Array.from(checkboxes).map(function(checkbox) {
//       return checkbox.value;
//     });

//     console.log(selectedOptions);
// }

const submitBtn = document.getElementById('submitBtn');
  submitBtn.addEventListener('click', collectCheckedValues);

  function collectCheckedValues() {
    const checkboxes = document.getElementsByName('myCheckbox');
    const checkedValues = [];

    checkboxes.forEach(checkbox => {
      if (checkbox.checked) {
        checkedValues.push(checkbox.value);
      }
    });

    console.log('Zaznaczone wartości:', checkedValues);
    // Możesz tutaj wykonać inne operacje na zebranych danych
  }