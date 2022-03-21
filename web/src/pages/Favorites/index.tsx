import React, {useEffect, useState} from 'react';
import { connection } from '../../api/connection';
import { useAppSelector } from '../../app/hooks';
import { selectUser } from '../../app/reducers/userSlice';
import Favorite from '../../components/Favorite';
import { Container } from '../../GlobalStyles';
import { IFavorite } from '../../models/Favorite';

import { FavoritesWrapper } from './styles';

export default function Favorites() {
    const [favorites, setFavorites] = useState<IFavorite[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    const user = useAppSelector(selectUser);

    useEffect(() => {
        setLoading(true);

        connection.get(`favorites/${user?.id}`).then(response => {
            setFavorites(response.data);
            setLoading(false);
        }).catch(err => {
            console.log(err);
        })
    }, [user?.id])

    if(loading) {
        return <p>Carregando...</p>
    }

    return (
        <Container>
            <FavoritesWrapper>
                {favorites.map(favorite => (
                    <Favorite key={favorite.id} {...favorite} />
                ))}
            </FavoritesWrapper>
        </Container>
    )
}