import React from 'react';

import { useAppDispatch } from '../../app/hooks';
import { ICartItem } from '../../types/product';

import { AddButton, CartProductWrapper, ProductImage, RemoveButton, ProductDescription, AddProduct } from './styles';
import { addProduct, removeProduct, removeQuantityOfProduct } from '../../app/reducers/cartSlice';
import { IoIosArrowDown, IoIosArrowUp } from 'react-icons/io';
import { baseURL } from '../../api/connection';

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
                <ProductImage src={`${baseURL}/images/${product.imageUrl}`} alt="product" />
            </td>
            <ProductDescription>
                <h2>{product.name}</h2>
                <p>{product.description}</p>
            </ProductDescription>
            <td>
                <AddProduct>
                    <AddButton onClick={handleRemoveQuatityOfProducts}>
                        <IoIosArrowDown size='15' />
                    </AddButton>
                    <span>{product.quantity}</span>
                    <AddButton onClick={handleAddProducts}>
                        <IoIosArrowUp size='15' />
                    </AddButton>
                </AddProduct>
                <div>
                    <RemoveButton onClick={handleRemoveProducts}>Remover</RemoveButton>
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