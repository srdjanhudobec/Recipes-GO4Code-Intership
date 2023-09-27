export class IngredientDTO{
    quantity: number;
    ingredientName: string;
    

    constructor(quantity: number,ingredientName: string){
        this.quantity = quantity;
        this.ingredientName = ingredientName;
    }

    
}