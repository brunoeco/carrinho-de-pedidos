import React from 'react';

import productImage from '../../assets/image.png';
import { useAppDispatch } from '../../app/hooks';
import { ICartItem } from '../../types/product';

import { CartProductWrapper, ProductImage } from './styles';
import { addProduct, removeProduct, removeQuantityOfProduct } from '../../app/reducers/cartSlice';

export default function CartProduct(product: ICartItem) {
    const dispatch = useAppDispatch();
    const subtotal = product.price * product.quantity;

    const handleAddProducts = () => {
        dispatch(addProduct(product));
    };

    const handleRemoveQuatityOfProducts = () => {
        dispatch(removeQuantityOfProduct(product.id))
    };

    const handleRemoveProducts = () => {
        dispatch(removeProduct(product.id))
    };

    return(
        <CartProductWrapper>
            <td>
                <ProductImage src={productImage} alt="product" />
            </td>
            <td>
                <h2>{product.name}</h2>
            </td>
            <td>
                <div>
                    <button onClick={handleRemoveQuatityOfProducts}>-</button>
                    <span>{product.quantity}</span>
                    <button onClick={handleAddProducts}>+</button>
                </div>
                <div>
                    <button onClick={handleRemoveProducts}>Remover</button>
                </div>
            </td>
            <td>
                <span>R$ {product.price.toFixed(2)}</span>
            </td>
            <td>
                <span>R$ {subtotal.toFixed(2)}</span>
            </td>
        </CartProductWrapper>
    );
}