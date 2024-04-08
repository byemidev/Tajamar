const display = document.getElementById("display");
let listaproductos = [];

const lblTotal = document.getElementById("total");
let precios = [];

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
    sumTotal();
}

let clicked = false; 
function quickOffProductFromList(id){
    //si el boton de la etiqueta del display para eliminar esta pulsado
    const delBtn = document.getElementById("delBtn");
    delBtn.addEventListener("click", () =>{
        //todo
        let clicked = true; 
        if(clicked){
            listaproductos.forEach(producto => {
                if(producto.id == id){
                    console.log(`Eliminando ${id}`)
                    display.removeChild(document.getElementById(`del${id}`));
                }
            });
        }
    });
    
}

function displayList() {
    console.log("en display list");
    display.innerHTML = '';
    
    listaproductos.forEach(producto => {
        const lbl = document.createElement('label');
        lbl.textContent = producto.displayText;
        
        const delBtn = document.createElement('button'); 
        delBtn.ariaSetSize = "1";
        delBtn.textContent = "delete";
        //poner propiedades id 
        //onclick , quickoffproducfromlist(del${id})    
        lbl.appendChild(delBtn);
        display.appendChild(lbl);
    });
}

function sumTotal(){

    let sum = 0.0;
    sum = precios.reduce((total, numero) => {
        return total + numero;
    }, 0);

    lblTotal.textContent = `Total: ${sum}`;
}




