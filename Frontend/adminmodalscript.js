
function openModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "block";
    document.getElementById("header-admin").style.zIndex = -1;
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "none";
    document.getElementById("header-admin").style.zIndex = 1;
}