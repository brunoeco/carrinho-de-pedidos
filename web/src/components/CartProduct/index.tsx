import React from 'react';

import productImage from '../../assets/image.png';
import { useAppDispatch } from '../../app/hooks';
import { ICartItem } from '../../types/product';

import { CartProductWrapper } from './styles';
import { addProduct, removeQuantityOfProduct } from '../../app/reducers/cartSlice';

export default function CartProduct(product: ICartItem) {
    const dispatch = useAppDispatch();

    const handleAddProducts = () => {
        dispatch(addProduct(product));
    };

    const handleRemoveProducts = () => {
        dispatch(removeQuantityOfProduct(product.id))
    };

    return(
        <CartProductWrapper>
            <img src={productImage} alt="product" />
            <h2>{product.name}</h2>
            <p>{product.price.toFixed(2)}</p>

            <button onClick={handleRemoveProducts}>-</button>
            <span>Quantidade: {product.quantity}</span>
            <button onClick={handleAddProducts}>+</button>
        </CartProductWrapper>
    );
}