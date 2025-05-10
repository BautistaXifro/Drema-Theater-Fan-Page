// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mostrarModal(titulo, descripcion, items) {
    document.getElementById("infoModalLabel").innerText = titulo;
    document.getElementById("modalDescription").innerText = descripcion;

    const lista = document.getElementById("modalList");
    lista.innerHTML = "";

    items.forEach(item => {
        const li = document.createElement("li");
    li.textContent = item;
    lista.appendChild(li);
    });

    const modal = new bootstrap.Modal(document.getElementById("infoModal"));
    modal.show();
}
