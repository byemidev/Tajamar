function main (){
        desplegable();
        showCheckBox();
        showRadio();
        isToday();
        isDate2GreaterThanDate1();
        minAge();
        getIVA();
}


        function desplegable(){
            let options = document.getElementById("colors__select").childNodes();
            options.foreach(option => {
                if(option && option.value){
                    console.log(option.node);
                    console.log(option.value);
                }
            });
        }

        function showCheckBox(){
            console.log("viendo checkboxs");
        }
        function showRadio(){
            console.log("viendo checkboxs");
        }
        
        function isToday(){

        }
        function isDate2GreaterThanDate1(){

        }
        function minAge(){

        }
        function getIVA(){

        }