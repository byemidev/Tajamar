function main() {
    desplegable();
    showCheckBox();
    showRadio();
    isToday();
    isDate2GreaterThanDate1();
    minAge();
    getIVA();
}

//revisar como manejar change, click .. addEventListener() 

function desplegable() {
    let selectElement = document.getElementById("colors__select");
    selectElement.addEventListener("change", (event) => {
        const selectedValue = event.target.value;
        console.log(`Selected color: ${selectedValue}`);
    });
}

function showCheckBox() { //falta evaluar si esta o no checked ese valor en especifico
    const fieldset = document.querySelector("fieldset[id='colors__checkbox']");
    const checkBoxs = fieldset.querySelectorAll("input[type='checkbox']");

    for(const checkBox of checkBoxs){
        checkBox.addEventListener("click", (event) =>{
            //si esta clieckeado haz...
            const selectedValue = event.target.value;
            console.log(`Selected value for checkbox ${selectedValue}`);
        });
    }
}

function showRadio() {
    const fieldsetElement = document.querySelector("fieldset[id='colors']");
    const radioButtons = fieldsetElement.querySelectorAll("input[type='radio']");

    for (const radioButton of radioButtons) {
        radioButton.addEventListener("change", (event) => {
            const selectedValue = event.target.value;
            console.log(`Selected value: ${selectedValue}`);
        });
    }
}

function isToday() {

}
function isDate2GreaterThanDate1() {

}
function minAge() {

}
function getIVA() {

}