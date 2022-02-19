import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IProduct } from '../../../models/Products';
import { ICart } from '../../../types/product';
import { RootState } from '../../store';


export function getCacheProducts() {
    const cartItems = localStorage.getItem('cartProductsRMT');

    console.log(typeof(cartItems));

    if(cartItems){
        const cartItemsParsed: ICart = JSON.parse(cartItems);

        return cartItemsParsed;
    }

    return [];
}

const cacheItems = getCacheProducts();

const initialState: ICart = cacheItems ? cacheItems : [];

export const cartSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        addProduct: (state, action: PayloadAction<IProduct>) => {
            const productExists = state.find(item => (
                item.id === action.payload.id
            ));
        
            if(!productExists) {
                const tempState = [
                    ...state, 
                    {
                        ...action.payload,
                        quantity: 1,
                    }
                ]

                localStorage.setItem('cartProductsRMT', JSON.stringify(tempState));

                return tempState;
            } else {
                const tempState = state.map(item => (
                    item.id !== action.payload.id ? item : { ...item, quantity: item.quantity + 1 }
                ))

                localStorage.setItem('cartProductsRMT', JSON.stringify(tempState));
                    
                return [
                    ...tempState
                ];
            }
        },

        removeQuantityOfProduct: (state, action: PayloadAction<number>) => {
            const tempState = state.filter(product => product.id !== action.payload || product.quantity > 1);

            if(tempState.length < state.length) {
                localStorage.setItem('cartProductsRMT', JSON.stringify(tempState));

                return [...tempState];
            }

            const returnState = state.map(product => {
                if(product.id !== action.payload) return product;
         
                return { ...product, quantity: product.quantity - 1 }
            })

            localStorage.setItem('cartProductsRMT', JSON.stringify(returnState));
            return [...returnState]
         },

        removeProduct: (state, action: PayloadAction<number>) => {
           const productExists = state.filter(product => (
                product.id !== action.payload
            ));

            localStorage.setItem('cartProductsRMT', JSON.stringify(productExists));

            return [
                ...productExists
            ];

        },
    }
});

export const { addProduct, removeProduct, removeQuantityOfProduct } = cartSlice.actions;

export const selectCart = (state: RootState) => state.cart;

export default cartSlice.reducer;