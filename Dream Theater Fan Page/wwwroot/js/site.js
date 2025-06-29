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

// INTEGRANTES

let integrantes = [];
function agregarIntegrante() {
    const nombre = document.getElementById('inputNombre').value.trim();
    const instrumento = document.getElementById('inputInstrumento').value.trim();
    const biografia = document.getElementById('inputBiografia').value.trim();

    if (!nombre || !instrumento || !biografia) {
        alert("Todos los campos son obligatorios.");
        return;
    }

    integrantes.push({nombre, instrumento, biografia});
    actualizarVistaIntegrantes();

    // Limpiar campos
    document.getElementById('inputNombre').value = '';
    document.getElementById('inputInstrumento').value = '';
    document.getElementById('inputBiografia').value = '';

    // Cerrar modal
    const modal = bootstrap.Modal.getInstance(document.getElementById('modalIntegrante'));
    modal.hide();
}

function actualizarVistaIntegrantes() {
    const lista = document.getElementById('listaIntegrantes');
    const campos = document.getElementById('camposIntegrantes');
    lista.innerHTML = '';
    campos.innerHTML = '';

        integrantes.forEach((i, index) => {
        lista.innerHTML += `
                    <li class="list-group-item">
                        <strong>${i.nombre}</strong> - ${i.instrumento}
                        <br><em>${i.biografia}</em>
                    </li>`;

    campos.innerHTML += `
    <input type="hidden" name="integrantes[${index}].Nombre" value="${i.nombre}" />
    <input type="hidden" name="integrantes[${index}].Instrumento" value="${i.instrumento}" />
    <input type="hidden" name="integrantes[${index}].Biografia" value="${i.biografia}" />
    `;
        });
}

function prepararIntegrantesParaEnvio() {
    actualizarVistaIntegrantes(); // en caso de no haberlo hecho antes
    return true;
}
