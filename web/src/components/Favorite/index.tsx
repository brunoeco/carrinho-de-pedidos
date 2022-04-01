import React from 'react';
import { IFavorite } from '../../models/Favorite';
import { IoIosClose } from 'react-icons/io';

import { FavoriteWrapper } from './styles';

import { baseURL, connection } from '../../api/connection';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { removeFavorites } from '../../app/reducers/favoritesSlice';
import { selectUser } from '../../app/reducers/userSlice';

export default function Favorite(favorite: IFavorite) {
    const dispatch = useAppDispatch();
    const user = useAppSelector(selectUser);

    const handleRemoveFavorite = async () => {
        try {
            await connection.delete(`favorites/${favorite.id}`, {
                headers: {
                    Authorization:  `Bearer ${user?.token}`
                }
            })
            .then(() => {
                dispatch(removeFavorites(favorite.id));
            })
            .catch(err => {
                console.log(err);
            });
        } catch(err) {
            console.log(err);
        }
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