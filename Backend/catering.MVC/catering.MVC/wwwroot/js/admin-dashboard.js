function openModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "block";
    document.getElementById("header-admin").style.zIndex = -1;
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "none";
    document.getElementById("header-admin").style.zIndex = 1;
}

var currentDiv = null;

function showDiv(divNumber) {
    if (currentDiv !== null) {
        currentDiv.style.display = "none";
    }

    var div = document.getElementById("div" + divNumber + "-admin");
    div.style.display = "flex";
    currentDiv = div;
}