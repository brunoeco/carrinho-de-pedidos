import React from 'react';

import { IProduct } from '../../models/Products';
import { AddCartButton, FavoriteProduct, ProductDescription, ProductImage, ProductInfo, ProductWrapper } from './styles';

import productImage from '../../assets/image.png';
import { IoIosHeartEmpty, IoMdCart } from 'react-icons/io';
import { useAppDispatch } from '../../app/hooks';
import { addProduct } from '../../app/reducers/cartSlice';

export default function Product(product: IProduct) {
    const dispatch = useAppDispatch();

    const handleAddProducts = () => {
        dispatch(addProduct(product));
    };

    return(
        <ProductWrapper>
            <ProductInfo>
                <FavoriteProduct>
                    <span>
                        <IoIosHeartEmpty size="25" />
                    </span>
                </FavoriteProduct>
                <ProductImage src={productImage} alt="product-image" />
                <ProductDescription>
                    <h2>{product.name}</h2>
                    <span>R$ {product.price.toFixed(2)}</span>
                </ProductDescription>
                <AddCartButton onClick={handleAddProducts}>
                    <IoMdCart size="25" />
                    COMPRAR
                </AddCartButton>
            </ProductInfo>
        </ProductWrapper>
    );
}