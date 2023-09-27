import { IngredientDTO } from "./IngredientDTO.model";

export class PostRecipe{
    name: string;
    ingredients: IngredientDTO [];
    description: string;

    constructor(name:string,ingredients:IngredientDTO [],description:string){
        this.name = name;
        this.ingredients = ingredients;
        this.description = description;
    }
}