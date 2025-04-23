///Declaracion de Variables
const selectDepa = document.getElementById("selectDepa")
const selectMuni = document.getElementById("selectMuni")
const tableClientes = document.getElementById("tableClientes")
const btnAgregar = document.getElementById("btnAgregar")
const btnEditar = document.getElementById("btnEditar")
const fragment = document.createDocumentFragment()
const dataTabla = new Map
let codigoProducto = null

///Obtener los distintos modelos
const fetchGetDepa = async () => {
    const idDepa = 1
    const response = await fetch(`/Paciente/getDepartamentos?idDepa=${idDepa}`)

    const data = await response.json()
    mostrarselect(data)
    console.log(data)
}

const fetchGetMuni = async (idDepa) => {
    const response = await fetch(`/Paciente/getMunicipio?idDepa=${idDepa}`)

    const data = await response.json()
    mostrarselectMunicipio(data)
}

const fetchGetClientes = async () => {
    const response = await fetch('/Paciente/getClientes');

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
    informacion.forEach(p => {
        const data = {
            codigo: p.codigo_paciente,
            dpi: p.dpi_paciente,
            nombre: p.nombre_paciente,
            apellido: p.apellido_paciente,
            fechaNac: p.fecha_nac,
            estado: p.estado_paciente,
            codMunicipio: p.codigo_municipio
        };
        dataTabla.set(p.codigo_paciente, data);

        const btnEliminar = `<button class="btn btn-danger btneliminar" data-codigo="${p.codigo_paciente}">Eliminar</button>`;
        const btnEditar = `<button class="btn btn-warning ms-2 btneditar" data-codigo="${p.codigo_paciente}">Editar</button>`;

        tableClientes.innerHTML +=
            `<tr>
                <td>${p.codigo_paciente}</td>
                <td>${p.dpi_paciente}</td>
                <td>${p.nombre_paciente} ${p.apellido_paciente}</td>
                <td>${new Date(p.fecha_nac).toLocaleDateString()}</td>
                <td>${p.estado_paciente ? 'Activo' : 'Inactivo'}</td>
                <td>${p.codigo_municipio}</td>
                <td>${btnEliminar}${btnEditar}</td>
            </tr>`;
    });
};


///Listeners
document.addEventListener('DOMContentLoaded', () => {
    fetchGetDepa()
    fetchGetClientes()
})

///Operaciones de CRUD
///Publicar
const fetchPostProducto = async (producto) => {

    const response = await fetch('Paciente/postProducto',
        {
            method:'POST',
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(producto)
        });
    const respuesta = await response.json()
    
    alert(respuesta.message)
    if (respuesta.data) {
       
        fetchGetClientes();
    } 

}
///
const fetchPutProducto = async (producto) => {

    const response = await fetch('Paciente/PutProducto',
        {
            method: 'PUT',
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(producto)
        });
    const respuesta = await response.json()

    alert(respuesta.message)
    if (respuesta.data) {

        fetchGetClientes();
    }

}
///Eliminar
const fetchDeleteProducto = async (codigoproducto) => {
    
    const response = await fetch(`/Paciente/deletePaciente?codigoPaciente=${codigoproducto}`)

    const respuesta = await response.json();
    alert(respuesta.message)
    if (respuesta.data) {
        fetchGetClientes();
    }
}
selectDepa.addEventListener('change', () => {
    const idDepa = parseInt(selectDepa.value);
    fetchGetMuni(idDepa);
});


//Eventos de Botones
tableClientes.addEventListener('click', async e=>   {
    const btneditar = e.target.closest('.btneditar')
    const btneliminar = e.target.closest('.btneliminar')
    if (btneditar) {
        const codigo = parseInt(btneditar.dataset.codigo)
        const valores = dataTabla.get(codigo)
        document.getElementById('innombre').value = valores.nombre;
        document.getElementById('inprecioc').value = valores.precioc;
        document.getElementById('inpreciov').value = valores.preciov;
        document.getElementById('inexistencia').value = valores.existencia;
        document.getElementById('incodigo').value = valores.codigo;
        codigoProducto = valores.codigo;
        console.log(valores.codigomodelo)
        selectmarca.value = valores.codigomarca.toString();
        await fetchGetModelo(valores.codigomarca)
        selectmodelo.value = valores.codigomodelo.toString();
    }
    else if (btneliminar) {
        const validar = confirm("Esta seguro que desea eliminar este producto?")
        if (validar) {
            const codigo = parseInt(btneliminar.dataset.codigo);
            fetchDeleteProducto(codigo);
        }
    }
    

})

btnAgregar.addEventListener('click', () => {
    const producto = {
        codigo: 0,
        dpi: document.getElementById('idDPI').value,
        nombre: document.getElementById('idNombre').value,
        apellido: document.getElementById('idApellido').value,
        fecha: document.getElementById('idFecha').value,
        estado: document.getElementById('idEstado').checked,
        codigomunicipio: parseInt(selectMuni.value),
        codigomarca:0
    }
    console.log(producto)

    fetchPostProducto(producto);
})
btnEditar.addEventListener('click', () => {
    let confirmacion = confirm("Esta seguro de editar este producto");
    if (confirmacion) {
        const producto = {
            codigo: codigoProducto,
    dpi: document.getElementById('idDPI').value,
    nombre: document.getElementById('idNombre').value,
    apellido: document.getElementById('idApellido').value,
    fechaNacimiento: document.getElementById('idFecha').value,
    estado: document.getElementById('idEstado').checked,
    codigodepa: parseInt(document.getElementById('selectDepa').value),
    codigomuni: parseInt(document.getElementById('selectMuni').value)
        }
        fetchPutProducto(producto)
    }
    else
        alert("No se edito nada")
   
})
