import { IUser } from "../../models/User";

export type PriceType = {
    min: number;
    max: number | null;
}

export type FilterState = {
    category: string;
    price: PriceType;
    search: string;
};

export interface UserState extends IUser {
    token: string;
}