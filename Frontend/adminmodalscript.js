
function openModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "block";
    document.getElementById("header-admin").style.zIndex = -1;
    document.querySelector('.file-name').textContent = "";
}

function closeModalAdminProduct() {
    document.getElementById("modal-create-admin").style.display = "none";
    document.getElementById("header-admin").style.zIndex = 1;
}

const file = document.querySelector('#file');
file.addEventListener('change', (e) => {
  const [file] = e.target.files;
  const { name: fileName, size } = file;
  const fileSize = (size / 1000).toFixed(2);
  const fileNameAndSize = `${fileName} - ${fileSize}KB`;
  document.querySelector('.file-name').textContent = fileNameAndSize;
});