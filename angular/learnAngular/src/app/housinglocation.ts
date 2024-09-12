export interface Housinglocation { // duda: crear una interfaz es una manera segura de obligar a implementar todas las propiedades. (en el caso de que quiera no implementarlas seria mejor construir un DTO o modelo??)
    id: number; 
    name: string; 
    city: string;
    state: string; 
    photo: string;
    availableUnits: number;
    wifi: boolean;
    laundry: boolean;
}
