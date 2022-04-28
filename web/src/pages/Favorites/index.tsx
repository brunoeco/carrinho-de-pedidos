import React, {useEffect, useState} from 'react';
import { useNavigate } from 'react-router-dom';

import { connection } from '../../api/connection';

import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { changeFavorites, selectFavorites } from '../../app/reducers/favoritesSlice';
import { selectUser } from '../../app/reducers/userSlice';

import Favorite from '../../components/Favorite';

import { Container, Title, Wrapper } from '../../GlobalStyles';

export default function Favorites() {
    const [loading, setLoading] = useState<boolean>(true);
    const favorites = useAppSelector(selectFavorites);
    const user = useAppSelector(selectUser);

    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    useEffect(() => {
        setLoading(true);

        connection.get(`favorites`, {
            params: {
                userId: user?.id
            },
            headers: {
                Authorization:  `Bearer ${user?.token}`
            }
        }).then(response => {
            dispatch(changeFavorites(response.data));
            setLoading(false);
        }).catch(err => {
            console.log(err);
            navigate('/login')
        })
    }, [user?.id, user?.token, dispatch, navigate])

    

    if(loading) {
        return <p className="message">Carregando...</p>
    }

    return (
        <Container>
                <Title>Favoritos</Title>

            <Wrapper>
                {favorites.length > 0 ? 
                    favorites.map(favorite => (
                        <Favorite key={favorite.id} {...favorite} />
                ))
                : <p className="message">Nenhum favorito encontrado.</p>
            }
                
            </Wrapper>
        </Container>
    )
}