const display = document.getElementById("display");

let listaproductos = [];

class Producto {
    id;
    nombre; 
    precio;
    displayText;
    constructor (id, nombre, precio){
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.displayText = `${nombre} : ${precio}`;
    }
}

function addProductToList(id, nombre, precio) {
    console.log("en add product");
    const producto = new Producto(id, nombre, precio);
    
    listaproductos.push(producto);
    
    console.log(`Added product: ${producto.id} with price: ${producto.precio}`);
    
    displayList();
    sumTotal(producto.precio);
}

function displayList() {
    console.log("en display list");
    display.innerHTML = '';

    listaproductos.forEach(producto => {
        const lbl = document.createElement('label');

        lbl.textContent = producto.displayText;

        display.appendChild(lbl);
    });
}


// no esta funcionando 
let precios = [];
var sum = 0.0;

function sumTotal(precio){
    precios.push(precio);
    console.log(precio);
    precios.forEach(precio => {
        sum += parseFloat(precio); 
    });
    return sum;
}

let lblTotal = document.getElementById("total");
function displayTotalSum(){
    console.log(lblTotal.nodeName);
}

function quickOffFromProducsList(name){
    //find by name and delete 
}




