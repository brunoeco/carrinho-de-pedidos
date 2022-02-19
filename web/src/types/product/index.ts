import { IProduct } from "../../models/Products";


export interface ICartItem extends IProduct {
    quantity: number;
}

export type ICart = Array<ICartItem>;