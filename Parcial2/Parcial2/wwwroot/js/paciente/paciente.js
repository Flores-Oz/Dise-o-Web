const selectDepa = document.getElementById("selectDepa");
const selectMuni = document.getElementById("selectMuni");
const tableClientes = document.getElementById("tableClientes");
const btnAgregar = document.getElementById("btnAgregar");
const btnEditar = document.getElementById("btnEditar");
const fragment = document.createDocumentFragment();
let codigoPaciente = null;

/// Función para mostrar alertas visuales
const mostrarAlerta = (mensaje, tipo = "success") => {
    const alerta = `
        <div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
            ${mensaje}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Cerrar"></button>
        </div>
    `;
    document.getElementById("alertContainer").innerHTML = alerta;

    setTimeout(() => {
        const alert = document.querySelector('.alert');
        if (alert) alert.remove();
    }, 4000);
};

/// Validación 
const validarFormulario = () => {
    let valido = true;

    const campos = [
        { id: "idCodigo" },
        { id: "idDPI" },
        { id: "idNombre" },
        { id: "idApellido" },
        { id: "idFecha" },
        { id: "selectDepa" },
        { id: "selectMuni" }
    ];

    campos.forEach(campo => {
        const input = document.getElementById(campo.id);
        if (!input.value || input.value.trim() === "") {
            input.classList.add("is-invalid");
            valido = false;
        } else {
            input.classList.remove("is-invalid");
        }
    });

    return valido;
};

/// CRUD y carga
const cargarDepartamentos = async () => {
    const response = await fetch("/Paciente/GetDepartamentos");
    const data = await response.json();

    selectDepa.innerHTML = "";
    const opcionDefault = document.createElement("option");
    opcionDefault.text = "-Seleccione Departamento-";
    opcionDefault.value = "";
    opcionDefault.disabled = true;
    opcionDefault.selected = true;
    fragment.appendChild(opcionDefault);

    data.forEach(d => {
        const opcion = document.createElement("option");
        opcion.value = d.value;
        opcion.text = d.text;
        fragment.appendChild(opcion);
    });

    selectDepa.appendChild(fragment);
    cargarMunicipios(selectDepa.value);
};

const cargarMunicipios = async (idDepa) => {
    const response = await fetch(`/Paciente/GetMunicipio?idDepa=${idDepa}`);
    const data = await response.json();

    selectMuni.innerHTML = "";
    const opcionDefault = document.createElement("option");
    opcionDefault.text = "-Seleccione Municipio-";
    opcionDefault.value = "";
    opcionDefault.disabled = true;
    opcionDefault.selected = true;
    fragment.appendChild(opcionDefault);

    data.forEach(m => {
        const opcion = document.createElement("option");
        opcion.value = m.value;
        opcion.text = m.text;
        fragment.appendChild(opcion);
    });

    selectMuni.appendChild(fragment);
};

const cargarPacientes = async () => {
    const response = await fetch("/Paciente/GetClientes");
    const data = await response.json();

    tableClientes.innerHTML = "";
    data.forEach(p => {
        const fila = `
            <tr>
                <td>${p.codigoPaciente}</td>
                <td>${p.dpiPaciente}</td>
                <td>${p.nombrePaciente}</td>
                <td>${p.apellidoPaciente}</td>
                <td>${p.fechaNac.substring(0, 10)}</td>
                <td>${p.estadoPaciente ? 'Activo' : 'Inactivo'}</td>
                <td>${p.municipio}</td>
                <td>${p.departamento}</td>
                <td>
                    <button class="btn btn-warning btn-sm me-1 btneditar" data-id='${JSON.stringify(p)}'>Editar</button>
                    <button class="btn btn-danger btn-sm btneliminar" data-id="${p.codigoPaciente}">Eliminar</button>
                </td>
            </tr>
        `;
        tableClientes.innerHTML += fila;
    });
};

const obtenerDatosFormulario = () => ({
    CodigoPaciente: parseInt(document.getElementById("idCodigo").value) || 0,
    DpiPaciente: document.getElementById("idDPI").value,
    NombrePaciente: document.getElementById("idNombre").value,
    ApellidoPaciente: document.getElementById("idApellido").value,
    FechaNac: document.getElementById("idFecha").value,
    EstadoPaciente: document.getElementById("idEstado").checked,
    CodigoMunicipio: parseInt(selectMuni.value),
    CodigoDepartamento: parseInt(selectDepa.value)
});

const limpiarFormulario = () => {
    document.getElementById("idCodigo").value = "";
    document.getElementById("idDPI").value = "";
    document.getElementById("idNombre").value = "";
    document.getElementById("idApellido").value = "";
    document.getElementById("idFecha").value = "";
    document.getElementById("idEstado").checked = false;
    selectDepa.selectedIndex = 0;
    cargarMunicipios(selectDepa.value);
    document.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));
};

const cargarFormulario = (paciente) => {
    document.getElementById("idCodigo").value = paciente.codigoPaciente;
    document.getElementById("idDPI").value = paciente.dpiPaciente;
    document.getElementById("idNombre").value = paciente.nombrePaciente;
    document.getElementById("idApellido").value = paciente.apellidoPaciente;
    document.getElementById("idFecha").value = paciente.fechaNac.substring(0, 10);
    document.getElementById("idEstado").checked = paciente.estadoPaciente;

    selectDepa.value = paciente.codigoDepartamento;
    cargarMunicipios(paciente.codigoDepartamento).then(() => {
        selectMuni.value = paciente.codigoMunicipio;
    });
};

const eliminarPaciente = async (id) => {
    if (!confirm("¿Seguro que deseas eliminar este paciente?")) return;
    const res = await fetch(`/Paciente/DeletePaciente?codigoPaciente=${id}`, {
        method: "DELETE"
    });
    const json = await res.json();
    mostrarAlerta(json.message, json.success ? "success" : "danger");
    cargarPacientes();
};

/// Eventos
document.addEventListener("DOMContentLoaded", () => {
    cargarDepartamentos();
    cargarPacientes();
});

selectDepa.addEventListener("change", () => {
    cargarMunicipios(selectDepa.value);
});

btnAgregar.addEventListener("click", async () => {
    if (!validarFormulario()) {
        mostrarAlerta("Por favor complete todos los campos obligatorios.", "danger");
        return;
    }

    const datos = obtenerDatosFormulario();
    const res = await fetch("/Paciente/PostPaciente", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos)
    });
    const json = await res.json();
    mostrarAlerta(json.message, json.success ? "success" : "danger");
    cargarPacientes();
    limpiarFormulario();
});

btnEditar.addEventListener("click", async () => {
    if (!validarFormulario()) {
        mostrarAlerta("Por favor complete todos los campos obligatorios.", "danger");
        return;
    }

    const datos = obtenerDatosFormulario();
    const res = await fetch("/Paciente/PutPaciente", {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos)
    });
    const json = await res.json();
    mostrarAlerta(json.message, json.success ? "success" : "danger");
    cargarPacientes();
    limpiarFormulario();
});

tableClientes.addEventListener("click", (e) => {
    if (e.target.classList.contains("btneliminar")) {
        const id = parseInt(e.target.dataset.id);
        eliminarPaciente(id);
    }
    if (e.target.classList.contains("btneditar")) {
        const paciente = JSON.parse(e.target.dataset.id);
        cargarFormulario(paciente);
    }
});
