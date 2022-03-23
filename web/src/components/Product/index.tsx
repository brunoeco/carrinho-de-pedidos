import React from 'react';

import { AddCartButton, FavoriteProduct, ProductDescription, ProductImage, ProductInfo, ProductWrapper } from './styles';

import { IoIosHeartEmpty, IoIosHeart, IoMdCart } from 'react-icons/io';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { addProduct } from '../../app/reducers/cartSlice';
import { baseURL, connection } from '../../api/connection';
import { selectUser } from '../../app/reducers/userSlice';
import { useNavigate } from 'react-router-dom';
import { IProductsProps } from '../../types/product';
import { addFavorites, removeFavorites, selectFavorites } from '../../app/reducers/favoritesSlice';
import { IFavorite } from '../../models/Favorite';

export default function Product({ product }: IProductsProps) {
    const dispatch = useAppDispatch();
    const user = useAppSelector(selectUser);
    const favorites = useAppSelector(selectFavorites);
    const navigate = useNavigate();

    const favorited = favorites.find(favorite => favorite.productId === product.id);

    const handleAddFavorite = async () => {
        if(!user) {
            return navigate('login');
        }

        try {
            const response = await connection.post('favorites', {
                userId: user.id,
                productId: product.id
            });

            const favorite = await (await connection.get<IFavorite>(`favorites/${response.data}`)).data;

            dispatch(addFavorites(favorite));

        } catch(err) {
            console.log(err);
        }
    };

    const handleRemoveFavorite = async (id: number) => {
        await connection.delete(`favorites/${id}`)
            .then(() => {
                dispatch(removeFavorites(id));
            })
            .catch(err => {
                console.log(err);
            });
    };

    const handleAddProducts = () => {
        dispatch(addProduct(product));
    };

    return(
        <ProductWrapper>
            <ProductInfo>
                <FavoriteProduct>
                    <span>
                        {favorited
                            ? <IoIosHeart size="25" onClick={() => { handleRemoveFavorite(favorited.id)}} />
                            : <IoIosHeartEmpty size="25" onClick={handleAddFavorite} />
                        }
                    </span>
                </FavoriteProduct>
                <ProductImage src={`${baseURL}/images/${product.imageUrl}`} alt="product-image" />
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