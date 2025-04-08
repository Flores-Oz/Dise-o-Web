const selectMarca = document.getElementById("selecMarca");
const selectModelo = document.getElementById("selecModelo");
const tbproducto = document.getElementById("tbproductos");
const btnagregar = document.getElementById("btnAgregar");
/*se crea un fraagmento de HTML (objetos) para agregarlo al DOM*/
const fragment = document.createDocumentFragment();

const fetchGetMarca = async () => {
    //const response = await fetch('/Producto/getMarcas')
    const response = await fetch('/Producto/getMarcas?idModelo=${idModelo}')
    const data = await response.json();
    mostrarSelect(data)
    console.log(data)
}

const fetchGetModelo = async () => {
    //const response = await fetch('/Producto/getModelo')
    const response = await fetch('/Producto/getModelo?idMarca=${idMarca}')
    const data = await response.json();
    mostrarSelect(data)
}

const fetchPostProducto = async (datos) => {
    const response = await fetch('Producto/postProducto', {
        method:'POST',
        headers:{ "Content=Type": "application/json; charset=utf8" },
        body:JSON.stringify(datos)
    })
    const request = await response.json();
    //if(request)
      //  alert('Producto Ingresado Correctamente')
    //else
    //  alert('Producto No Ingresado Correctamente')
    alert(request.message)
    if (request.data)
        fetchgetProducto()
} 

const mostrarSelect = (data) => {
    selectMarca.innerHTML = '';
    const defaultOption = document.createElement('option')
    defaultOption.text = 'Seleccione una Marca'
    defaultOption.value = ''
    defaultOption.disabled = true
    defaultOption.selected = true
    fragment.appendChild(defaultOption)

    data.forEach(mr => {
        const opction = document.createElement('option')
        opction.value = mr.value
        opction.text = mr.text
        fragment.appendChild(opction)
    })

    selectMarca.appendChild(fragment)
}

const mostrarModelo = (data) => {
    selectModelo.innerHTML = '';
    const defaultOption = document.createElement('option')
    defaultOption.text = 'Seleccione un Modelo'
    defaultOption.value = ''
    defaultOption.disabled = true
    defaultOption.selected = true
    fragment.appendChild(defaultOption)

    data.forEach(mr => {
        const opction = document.createElement('option')
        opction.value = mr.value
        opction.text = mr.text
        fragment.appendChild(opction)
    })

    selectModelo.appendChild(fragment)
}

const pintartable = (informacion) => {
    tbproducto.innerHTML = '';
    informacion.forEach(pr => {
        const btneliminar = `<button class="btn btn-danger btneliminar" data-codigo="${pr.codigo}" >Eliminar</button>`
        const btneditar = `<button class="btn btn-warning ms-2 btneditar" data-codigo="${pr.codigo}">Editar</button>`
        tbproducto.innerHTML +=
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

tbproducto.addEventListener('click', async e =>
{
    const btneditar = e.target.closest('.btneditar')
    const codigo = btneditar.dataset.codigo
    console.log(codigo)
})

document.addEventListener("DOMContentLoaded", () => {
    fetchGetMarca()
})

selectMarca.addEventListener('change', () => {
    const valorMarca = parseInt(selectMarca.value)
    fetchGetModelo(valorMarca)
})

btnagregar.addEventListener('click', () => {
    const producto = {
        codigo: document.getElementById('inCodigo').value,
        nombre: document.getElementById('innombre').value,
        precioc: document.getElementById('inprecioCosto').value,
        preciov: document.getElementById('inprecioVenta').value,
        existencia: document.getElementById('inExistencia').value,
        codigoModelo: parseInt(selectModelo.value)
    }
    console.log(producto)
    //fetchPostProducto()
})