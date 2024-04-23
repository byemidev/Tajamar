
//para $_SESSION
const session_id = {
    id: null,
    set setID(new_id){
        this.id = new_id;
    },
    get getID(){
        return this.id;
    }
};

//para objetos form
const form_data = {
    nombre: null, desc: null, 
    set setNombre(_nombre){
        this.nombre = _nombre;
    },
    get getNombre(){
        return this.nombre;
    }, 
    set setDesc(_desc){
        this.desc = _desc;
    }, 
    get getDesc(){
        return this.desc;
    }
};

const btnAdd = document.querySelector(".add");
btnAdd.addEventListener("click" , (event)=>{
    console.log('se ha producido el evento' + event.target.value);
    session_id.setID= event.target.value;
    console.log(session_id.getID);
    window.location.href="registro.php";
});


