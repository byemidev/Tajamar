const btnAdd = document.getElementById("add");

btnAdd.addEventListener("click" , (event)=>{
        var value = event.target.value;
        switch(value){
            case "1":
            //insertar en madrid
                window.URL('insertMadrid.php');
                break;
            case "2": 
            //insertar en barcelona
                break;
            case "3": 
            //insertar en andalucia
                break;

            case "4": 
            //valencia
                break;
        }
});
