import { IFavorite } from "../../models/Favorite";
import { IProduct } from "../../models/Product";


export interface ICartItem extends IProduct {
    quantity: number;
}

export type ICart = Array<ICartItem>;

export interface IProductsProps  {
    product: IProduct;
}