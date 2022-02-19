
export type PriceType = {
    start: number;
    end: number;
}

export type FilterState = {
    category: Array<string>;
    price: PriceType;
};