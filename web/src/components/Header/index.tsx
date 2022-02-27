import React from 'react'
import { IoMdCart, IoIosHeart, IoIosSearch, IoMdPerson } from 'react-icons/io';
import { useAppDispatch, useAppSelector } from '../../app/hooks';

import { cleanCart, selectCart } from '../../app/reducers/cartSlice';
import { logout, selectUser } from '../../app/reducers/userSlice';

import { Link, useNavigate } from 'react-router-dom';
import { HeaderWrapper, IconLinks, Profile, Logo, MenuList, SearchForm, LogoutButton } from './styles';

import logoImage from '../../assets/logo.png';

export default function Header() {
    const cart = useAppSelector(selectCart);
    const user = useAppSelector(selectUser);
    const session = user ? true : false;

    const navigate = useNavigate();

    const dispatch = useAppDispatch();

    const handleLogout = () => {
        dispatch(logout());
        dispatch(cleanCart());
        navigate(0);
    }

    return (
        <HeaderWrapper>
            <MenuList>
                <Link to='/'>
                    <Logo src={logoImage} alt="logo" />
                </Link>

                <SearchForm>
                    <input type="search" placeholder="Busque aqui" />
                    <button>
                        <IoIosSearch size="30" />
                    </button>
                </SearchForm>
                
                <Profile>
                    {session 
                        ? (
                            <>
                                <Link to='/'>Perfil</Link>
                                <span>|</span>
                                <LogoutButton onClick={handleLogout}>Sair</LogoutButton>
                            </>
                        )
                        : <Link to='/login'>Faça login</Link>
                    }
                </Profile>


                <IconLinks>
                    <Link to='/'>
                        <IoIosHeart size="25" />
                    </Link>

                    <Link to='/cart'>
                        <IoMdCart size="25" />
                        <span>{cart.reduce((total, cart) => (total + cart.quantity), 0)}</span>
                    </Link>
                </IconLinks>
                
            </MenuList>
        </HeaderWrapper>
    )
}