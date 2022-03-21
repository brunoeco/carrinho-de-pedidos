import { IProduct } from "../../models/Product";


export interface ICartItem extends IProduct {
    quantity: number;
}

export type ICart = Array<ICartItem>;