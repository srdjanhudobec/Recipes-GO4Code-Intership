export class Ingredient{
    id:number;
    name: string;
    measurementUnit: string;
    

    constructor(Id:number,Name: string,MeasurementUnit: string){
        this.id = Id;
        this.name = Name;
        this.measurementUnit = MeasurementUnit;
    }
}