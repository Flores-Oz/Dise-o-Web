const selectDepa = document.getElementById("selectDepa");
const selectMuni = document.getElementById("selectMuni");
const tableClientes = document.getElementById("tableClientes");
const btnAgregar = document.getElementById("btnAgregar");
const btnEditar = document.getElementById("btnEditar");
const btnImprimir = document.getElementById("btnImprimir");
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
        { id: "idID" },
        { id: "idNombre" },
        { id: "idDireccion" },
        { id: "idTelefono" },
        { id: "idCorreo" },
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
    const response = await fetch("/PDF/GetDepartamentos");
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
    const response = await fetch(`/PDF/GetMunicipio?idDepa=${idDepa}`);
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

const cargarClientes = async () => {
    const response = await fetch("/PDF/GetClientes");
    const data = await response.json();

    tableClientes.innerHTML = "";
    data.forEach(p => {
        const fila = `
            <tr>
                <td>${p.id}</td>
                <td>${p.nombre}</td>
                <td>${p.direccion}</td>
                <td>${p.telefono}</td>
                <td>${p.correo}</td>
                <td>${p.municipio}</td>
                <td>${p.departamento}</td>
                <td>
                    <button class="btn btn-warning btn-sm me-1 btneditar" data-id='${JSON.stringify(p)}'>Editar</button>
                    <button class="btn btn-danger btn-sm btneliminar" data-id="${p.codigoPaciente}">Eliminar</button>
                    <button class="btn btn-info btn-sm btnimprimir" data-id='${JSON.stringify(p)}'>Imprimir recibo</button>
                </td>
            </tr>
        `;
        tableClientes.innerHTML += fila;
    });
};

const obtenerDatosFormulario = () => ({
    ID: parseInt(document.getElementById("idID").value),
    Nombre: document.getElementById("idNombre").value,
    Direccion: document.getElementById("idDireccion").value,
    Telefono: document.getElementById("idTelefono").value,
    Correo: document.getElementById("idCorreo").value,
    MunicipioId: parseInt(selectMuni.value),
    CodigoDepartamento: parseInt(selectDepa.value)
});

const limpiarFormulario = () => {
    document.getElementById("idID").value = "";
    document.getElementById("idNombre").value = "";
    document.getElementById("idDireccion").value = "";
    document.getElementById("idTelefono").value = "";
    document.getElementById("idCorreo").value = "";
    selectDepa.selectedIndex = 0;
    cargarMunicipios(selectDepa.value);
    document.querySelectorAll(".is-invalid").forEach(el => el.classList.remove("is-invalid"));
};

const cargarFormulario = (Cliente) => {
    document.getElementById("idID").value = Cliente.id;
    document.getElementById("idNombre").value = Cliente.nombre;
    document.getElementById("idDireccion").value = Cliente.direccion;
    document.getElementById("idTelefono").value = Cliente.telefono;
    document.getElementById("idCorreo").value = Cliente.correo;
    selectDepa.value = Cliente.codigoDepartamento;
    cargarMunicipios(Cliente.codigoDepartamento).then(() => {
        selectMuni.value = Cliente.municipioId;
    });
};

const eliminarCliente = async (id) => {
    if (!confirm("¿Seguro que deseas eliminar este Cliente?")) return;
    const res = await fetch(`/PDF/DeletePaciente?codigoCliente=${id}`, {
        method: "DELETE"
    });
    const json = await res.json();
    mostrarAlerta(json.message, json.success ? "success" : "danger");
    cargarClientes();
};

//Eventos
document.addEventListener("DOMContentLoaded", () => {
    cargarDepartamentos();
    cargarClientes();
});

selectDepa.addEventListener("change", (e) => {
    cargarMunicipios(e.target.value);
});

btnAgregar.addEventListener("click", async () => {
    if (!validarFormulario()) {
        mostrarAlerta("Por favor complete todos los campos obligatorios.", "danger");
        return;
    }

    const datos = obtenerDatosFormulario();
    const res = await fetch("/PDF/PostCliente", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos)
    });
    const json = await res.json();
    mostrarAlerta(json.message, json.success ? "success" : "danger");
    cargarClientes();
    limpiarFormulario();
});

btnEditar.addEventListener("click", async () => {
    if (!validarFormulario()) {
        mostrarAlerta("Por favor complete todos los campos obligatorios.", "danger");
        return;
    }

    const datos = obtenerDatosFormulario(); // <-- ESTO FALTABA

    const res = await fetch("/PDF/PutCliente", {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datos)
    });

    if (!res.ok) {
        console.error("Error en la respuesta del servidor", await res.text());
    } else {
        const json = await res.json();
        mostrarAlerta(json.message, json.success ? "success" : "danger");
        cargarClientes();
        limpiarFormulario();
    }
});

tableClientes.addEventListener("click", (e) => {
    if (e.target.classList.contains("btneliminar")) {
        const id = parseInt(e.target.dataset.id);
        eliminarCliente(id);
    }
    if (e.target.classList.contains("btneditar")) {
        const cliente = JSON.parse(e.target.dataset.id);
        cargarFormulario(cliente);
    }
     if (e.target.classList.contains("btnimprimir")) {
        const cliente = JSON.parse(e.target.dataset.id);
        generarPDF(cliente);
    }
});

//Boton en la Tabla
const generarPDF = (cliente) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

        // Título
        doc.setFontSize(18);
        doc.setTextColor(33, 37, 41);
        doc.text("Recibo de Cliente", 20, 30);

        // Línea decorativa
        doc.setLineWidth(0.5);
        doc.line(20, 35, 190, 35);

        // Info del cliente en tabla
        doc.autoTable({
            startY: 40,
            theme: 'grid',
            headStyles: { fillColor: [220, 53, 69] }, // estilo Bootstrap rojo
            body: [
                ['ID', cliente.id],
                ['Nombre', cliente.nombre],
                ['Dirección', cliente.direccion],
                ['Teléfono', cliente.telefono],
                ['Correo', cliente.correo],
                ['Municipio', cliente.municipio],
                ['Departamento', cliente.departamento]
            ],
            styles: {
                fontSize: 12,
                halign: 'left',
                cellPadding: 3
            },
            columnStyles: {
                0: { fontStyle: 'bold', textColor: [52, 58, 64] }, // gris oscuro
                1: { textColor: [33, 37, 41] }
            }
        });

        // Pie de página
        const fecha = new Date().toLocaleString();
        doc.setFontSize(10);
        doc.setTextColor(100);
        doc.text(`Generado el: ${fecha}`, 20, doc.internal.pageSize.height - 10);

        doc.save(`Ficha_${cliente.nombre}.pdf`);
};

//Boton de Imprimir Evento
btnImprimir.addEventListener("click", async () => {
      try {
        const response = await fetch("/PDF/GetClientes");
        const clientes = await response.json();

        const { jsPDF } = window.jspdf;
        const doc = new jsPDF("landscape"); 

        // Aquí puedes usar el logo en formato base64 (si lo tienes) o URL
        const logoBase64 = 'https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/08a8adad-7f5e-4ce3-9b94-9c6291562edc/di9xk39-757bd45b-093f-46b1-8bb5-d9263acb9e2e.png/v1/fill/w_894,h_894/legend_gochizo_logo_base_by_eternalrider97_di9xk39-pre.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTI4MCIsInBhdGgiOiJcL2ZcLzA4YThhZGFkLTdmNWUtNGNlMy05Yjk0LTljNjI5MTU2MmVkY1wvZGk5eGszOS03NTdiZDQ1Yi0wOTNmLTQ2YjEtOGJiNS1kOTI2M2FjYjllMmUucG5nIiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.C5y3NPqOcj5SSI-uZNwZhdd8YjIovaGJ2sD1iVjdmuI';  // Reemplaza esto con tu base64 o URL del logo

        // Agregar logo al PDF (si existe)
        if (logoBase64) {
            doc.addImage(logoBase64, 'PNG', 10, 10, 40, 20);  // x, y, ancho, alto
        }

        // Título del documento
        doc.setFontSize(16);
        doc.text("Listado de Clientes", 80, 20);

        // Crear tabla con los datos de los clientes
        doc.autoTable({
            startY: 30, // Empieza la tabla debajo del título
            head: [["ID", "Nombre", "Dirección", "Teléfono", "Correo", "Municipio", "Departamento"]],
            body: clientes.map(c => [
                c.id,
                c.nombre,
                c.direccion,
                c.telefono,
                c.correo,
                c.municipio,
                c.departamento
            ]),
            styles: {
                fontSize: 10,
                cellPadding: 2
            },
            headStyles: {
                fillColor: [220, 53, 69],
                textColor: 255,
                fontStyle: 'bold'
            }
        });

        // Fecha de generación
        const fecha = new Date().toLocaleString();
        doc.setFontSize(10);
        doc.setTextColor(100);
        doc.text(`Generado el: ${fecha}`, 20, doc.internal.pageSize.height - 10);

        // Descargar el PDF
        doc.save("Listado_Clientes.pdf");
    } catch (error) {
        console.error("Error al obtener los clientes:", error);
    }
});