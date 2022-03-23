import React from 'react';
import { IFavorite } from '../../models/Favorite';
import { IoIosClose } from 'react-icons/io';

import { FavoriteWrapper } from './styles';

import { baseURL, connection } from '../../api/connection';
import { useAppDispatch } from '../../app/hooks';
import { removeFavorites } from '../../app/reducers/favoritesSlice';

export default function Favorite(favorite: IFavorite) {
    const dispatch = useAppDispatch();

    const handleRemoveFavorite = async () => {
        await connection.delete(`favorites/${favorite.id}`)
            .then(() => {
                dispatch(removeFavorites(favorite.id));
            })
            .catch(err => {
                console.log(err);
            });
    };

    return (
        <FavoriteWrapper id={`favorite-${favorite.id}`}>
            <img src={`${baseURL}/images/${favorite.product.imageUrl}`} alt={favorite.product.name} />
            <p>{favorite.product.name}</p>
            <span id="price" >R$ {favorite.product.price}</span>
            <span>
                <IoIosClose 
                    size={35} 
                    color="red" 
                    onClick={handleRemoveFavorite}
                />
            </span>
        </FavoriteWrapper>
    )
}