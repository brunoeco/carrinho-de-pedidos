import { Request, Response } from "express";
import { fakeDb } from "../fakeDb";
import { IProductsFilter } from "../types";

export default {
    index(req: Request<{},any,any,IProductsFilter>, res: Response) {
        const { 
            category = '', 
            max_price = null, 
            min_price = 0, 
            search = ''
        } = req.query;

        const products = fakeDb.products.filter(product => {
            return (product.category.includes(category) 
                    && product.price > min_price
                    && max_price !== null ? product.price <= max_price : false
                    && (product.name.includes(search) || product.description.includes(search))
                    );
        })

        return res.json(products);
    }
}