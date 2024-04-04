const display = document.getElementById("display");
const listaproductos = null;


class producto{
    precio;
    nombre;
    constructor(nombre, precio){
        this.nombre = nombre;
        this.precio = precio;
    }
}

function addProductToList(nombre, precio){
    //añado mis productos a una lista para trabajar a nivel local
    listaproductos.push(new producto(nombre, precio));
    //me interesa cambiar el color de producto selecionado para saber que esta seleccionado y que se muestre por pantalla con shosDisplay()
    //como trabajo en este nodo = producto (byClassName())
}

function displayList(){
    listaproductos.forEach(producto => {
        let lbl = document.createElement(label);
        let text = document.createTextNode(producto.nombre);
        lbl.appendChild(text);
        display.appendChild(lbl);
    });
}

function quickOffFromProducsList(name){
    //find by name and delete 
}




