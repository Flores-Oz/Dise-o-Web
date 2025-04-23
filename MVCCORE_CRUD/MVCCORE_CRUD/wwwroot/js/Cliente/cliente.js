///Declaracion de Variables
const selectDepa = document.getElementById("selectDepa")
const selectMuni = document.getElementById("selectMuni")
const tableClientes = document.getElementById("tableClientes")
const btnAgregar = document.getElementById("btnAgregar")
const btnEditar = document.getElementById("btnEditar")
const fragment = document.createDocumentFragment()
const dataTabla = new Map

///Obtener los distintos modelos
const fetchGetDepa = async () => {
    const idDepa = 1
    const response = await fetch(`/Cliente/getDepartamentos?idDepa=${idDepa}`)

    const data = await response.json()
    mostrarselect(data)
    console.log(data)
}

const fetchGetMuni = async (idDepa) => {
    const response = await fetch(`/Cliente/getMunicipio?idDepa=${idDepa}`)

    const data = await response.json()
    mostrarselectMunicipio(data)
}

const fetchGetClientes = async () => {
    const response = await fetch('/Cliente/getClientes');

    const informacion = await response.json();
    pintartable(informacion);

}

const mostrarselect = (data) => {
    selectDepa.innerHTML = '';
    const defaulopcion = document.createElement('option');
    defaulopcion.text = '-Seleccione Departamento-';
    defaulopcion.value = '';
    defaulopcion.disabled = true;
    defaulopcion.selected = true;
    fragment.appendChild(defaulopcion);

    data.forEach(mr => {
        const opcion = document.createElement('option');
        opcion.value = mr.value;
        opcion.text = mr.text;
        fragment.appendChild(opcion);
    })
    selectDepa.appendChild(fragment);

}

const mostrarselectMunicipio = (data) => {
    selectMuni.innerHTML = '';
    const defaulopcion = document.createElement('option');
    defaulopcion.text = '-Seleccione Municipio-';
    defaulopcion.value = '';
    defaulopcion.disabled = true;
    defaulopcion.selected = true;
    fragment.appendChild(defaulopcion);

    data.forEach(mr => {
        const opcion = document.createElement('option');
        opcion.value = mr.value;
        opcion.text = mr.text;
        fragment.appendChild(opcion);
    })
    selectMuni.appendChild(fragment);
}

///MostrarTabla
const pintartable = (informacion) => {
    tableClientes.innerHTML = '';
    informacion.forEach(cl => {
        const data = {
            nit: cl.nitCliente,
            nombre: cl.nombreCliente,
            apellido: cl.apellidoCliente,
            direccion: cl.direccionCliente,
            telefono: cl.telefonoCliente,
            fechanac: cl.fechanacCliente,
            estado: cl.estadoCliente,
            municipio: cl.municipio,
            departamento: cl.departamento,
            codMunicipio: cl.codigoMunicipio,
            codDepartamento: cl.codigoDepartamento
        };
        dataTabla.set(cl.nitCliente, data);

        const btnEliminar = `<button class="btn btn-danger btneliminar" data-nit="${cl.nitCliente}">Eliminar</button>`;
        const btnEditar = `<button class="btn btn-warning ms-2 btneditar" data-nit="${cl.nitCliente}">Editar</button>`;

        tableClientes.innerHTML +=
            `<tr>
                <td>${cl.nitCliente}</td>
                <td>${cl.nombreCliente} ${cl.apellidoCliente}</td>
                <td>${cl.direccionCliente}</td>
                <td>${cl.telefonoCliente}</td>
                <td>${new Date(cl.fechanacCliente).toLocaleDateString()}</td>
                <td>${cl.estadoCliente ? 'Activo' : 'Inactivo'}</td>
                <td>${cl.municipio}, ${cl.departamento}</td>
                <td>${btnEliminar}${btnEditar}</td>
            </tr>`;
    });
};

///Listeners
document.addEventListener('DOMContentLoaded', () => {
    fetchGetDepa()
    fetchGetClientes()
})

selectDepa.addEventListener('change', () => {
    const idDepa = parseInt(selectDepa.value);
    fetchGetMuni(idDepa);
});
