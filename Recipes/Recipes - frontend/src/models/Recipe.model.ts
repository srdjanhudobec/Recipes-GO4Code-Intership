import { IngredientDTO } from "./IngredientDTO.model";

export class Recipe{
    id: number;
    name: string;
    ingredients: IngredientDTO [];
    description: string;
    creatorUsername: string;
    

    constructor(id:number,name:string,ingredients:IngredientDTO[],description:string,creatorUsername:string){
        this.id = id;
        this.name = name;
        this.ingredients = ingredients;
        this.description = description;
        this.creatorUsername = creatorUsername;
    }
}