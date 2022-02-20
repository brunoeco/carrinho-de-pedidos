
export type PriceType = {
    min: number;
    max: number | null;
}

export type FilterState = {
    category: string;
    price: PriceType;
};