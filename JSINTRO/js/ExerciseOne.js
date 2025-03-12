const producto={
    ID:"123",
    Nombre:"Agua Pura",
    Tipo:"Botella",
    Marca:"Salvavidas",
    Precio:"5.00"     
}

const numeros=[15,26,58]
console.log(numeros)
numeros.push(24)
console.log(numeros)
numeros.unshift(1)
console.log(numeros)
console.log(numeros.length)

numeros[2] =2
console.log(numeros)

numeros.pop()
console.log(numeros)

for(var item of numeros){
    console.log(item)
}
