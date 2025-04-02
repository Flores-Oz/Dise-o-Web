const producto={
    ID:"123",
    Nombre:"Agua Pura",
    Tipo:"Botella",
    Marca:"Salvavidas",
    Precio:"5.00"     
}

const cliente={
    nit: 123,
    Nombre: "Jose",
    edad: 23
}

const {ID,Nombre,Tipo,Marca,Precio} = producto
console.log(ID,Nombre,Tipo,Marca,Precio)

const {nit,Nombre:nombreCliente,edad} = cliente
console.log(nit,nombreCliente,edad)

const nuevoObjeto = {...producto,...cliente}
console.table(nuevoObjeto)