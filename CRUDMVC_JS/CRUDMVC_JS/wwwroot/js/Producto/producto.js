const selectMarca = document.getElementById("selecMarca");
/*se crea un fraagmento de HTML (objetos) para agregarlo al DOM*/
const fragment = document.createDocumentFragment();

const fetchGetMarca = async () => {
    const response = await fetch('/Producto/getMarcas')
    //const response = await fetch('/Producto/getMarcas?idModelo=${idMarca}')
    const data = await response.json();
    mostrarSelect(data)
    console.log(data)
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

document.addEventListener("DOMContentLoaded", () => {
    fetchGetMarca()
})