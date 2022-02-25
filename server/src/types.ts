export type UserType = {
    id: number;
    name: string;
    username: string;
    password: string;
} | undefined;

export type UserGetProps = {
    username: string;
    password: string;
}

export type IProductsFilter = {
    category: string,
    max_price: number | null,
    min_price: number,
    search: string
}