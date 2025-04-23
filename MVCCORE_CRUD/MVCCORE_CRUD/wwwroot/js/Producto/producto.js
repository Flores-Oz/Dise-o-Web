///Declaracion de Varialbes
const selectmarca = document.getElementById("selectmarca")
const selectmodelo = document.getElementById("selectmodelo")
const tableProductos = document.getElementById("tableProductos")
const btnAgregar = document.getElementById("btnAgregar")
const btnEditar = document.getElementById("btnEditar")

const fragment = document.createDocumentFragment()
const dataTabla = new Map()
let codigoProducto = null

///Obtener los distintos modelos
const fetchGetMarca = async ( ) => {
    const idmodelo = 1
    const response = await fetch(`/Producto/getMarcas?idmodelo=${idmodelo}`)

    const data = await response.json()
    mostrarselect(data)
    console.log(data)
}

const fetchGetModelo = async (idMarca) => {
    const idModelo = 1
    const response = await fetch(`/Producto/getModelo?idmarca=${idMarca}`)

    const data = await response.json()
    mostrarselectModelo(data)
}

const fetchGetProducto = async () => {
    const response = await fetch('/Producto/getProductos');

    const informacion = await response.json();
    pintartable(informacion);

}


///Operaciones de CRUD
///Publicar
const fetchPostProducto = async (producto) => {

    const response = await fetch('Producto/postProducto',
        {
            method:'POST',
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(producto)
        });
    const respuesta = await response.json()
    
    alert(respuesta.message)
    if (respuesta.data) {
       
        fetchGetProducto();
    } 

}
///
const fetchPutProducto = async (producto) => {

    const response = await fetch('Producto/PutProducto',
        {
            method: 'PUT',
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(producto)
        });
    const respuesta = await response.json()

    alert(respuesta.message)
    if (respuesta.data) {

        fetchGetProducto();
    }

}
///Eliminar
const fetchDeleteProducto = async (codigoproducto) => {
    
    const response = await fetch(`/Producto/deleteProdcuto?codigoproducto=${codigoproducto}`)

    const respuesta = await response.json();
    alert(respuesta.message)
    if (respuesta.data) {
        fetchGetProducto();
    }
}

///MostrarTabla
const pintartable = (informacion) => {
    tableProductos.innerHTML = '';
    informacion.forEach(pr => {
        const data = {
            codigo:pr.codigo,
            nombre: pr.nombre,
            precioc: pr.precioc,
            preciov: pr.preciov,
            existencia: pr.existencia,
            codigomarca: pr.codigomarca,
            codigomodelo:pr.codigomodelo

        }
        dataTabla.set(pr.codigo, data);

        const btneliminar = `<button class="btn btn-danger btneliminar" data-codigo="${pr.codigo}" >Eliminar</button>`
        const btneditar = `<button class="btn btn-warning ms-2 btneditar" data-codigo="${pr.codigo}">Editar</button>`
        tableProductos.innerHTML +=
            `<tr>
                <td>${pr.codigo}</td>
                <td>${pr.nombre}</td>
                <td>${pr.marca}</td>
                <td>${pr.precioc}</td>
                <td>${pr.preciov}</td>
                <td>${pr.existencia}</td>
                <td>${btneliminar}${btneditar}</td>
            </tr>`
    })

}

const mostrarselect = (data) => {
    console.log("Modelos recibidos:", data)
    selectmarca.innerHTML = '';
    const defaulopcion = document.createElement('option');
    defaulopcion.text = '-Seleccione una Marca-';
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
    selectmarca.appendChild(fragment);

}
const mostrarselectModelo = (data) => {
    selectmodelo.innerHTML = '';
    const defaulopcion = document.createElement('option');
    defaulopcion.text = '-Seleccione una Modelo-';
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
    selectmodelo.appendChild(fragment);
}

///Listeners
document.addEventListener('DOMContentLoaded', () => {
    fetchGetMarca()
    fetchGetProducto()
})

selectmarca.addEventListener('change', () => {
    const valormarca = parseInt(selectmarca.value)
    console.log(valormarca)
    fetchGetModelo(valormarca);
})

//Eventos de Botones
tableProductos.addEventListener('click', async e=>   {
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
        nombre: document.getElementById('innombre').value,
        precioc: parseFloat(document.getElementById('inprecioc').value),
        preciov: parseFloat(document.getElementById('inpreciov').value),
        existencia: parseInt(document.getElementById('inexistencia').value),
        codigomodelo: parseInt(selectmodelo.value),
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
            nombre: document.getElementById('innombre').value,
            precioc: parseFloat(document.getElementById('inprecioc').value),
            preciov: parseFloat(document.getElementById('inpreciov').value),
            existencia: parseInt(document.getElementById('inexistencia').value),
            codigomodelo: parseInt(selectmodelo.value),
            codigomarca: 0
        }
        fetchPutProducto(producto)
    }
    else
        alert("No se edito nada")
   
})


