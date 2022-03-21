import { IProduct } from "./Product";

export interface IFavorite {
    id: number;
    productId: number;
    createdAt: Date;
    product: IProduct;
}