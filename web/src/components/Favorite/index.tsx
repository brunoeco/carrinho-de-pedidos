import React from 'react';
import { IFavorite } from '../../models/Favorite';
import { IoIosClose } from 'react-icons/io';

import { FavoriteWrapper } from './styles';

import productImage from '../../assets/image.png';

export default function Favorite(props: IFavorite) {
    return (
        <FavoriteWrapper>
            <img src={productImage} alt={props.product.name} />
            <p>{props.product.name}</p>
            <span id="price" >R$ {props.product.price}</span>
            <span><IoIosClose size={35} color="red" /></span>
        </FavoriteWrapper>
    )
}