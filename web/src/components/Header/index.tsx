import React from 'react'
import { IoMdCart, IoIosHeart, IoIosSearch, IoMdPerson } from 'react-icons/io';
import { useAppSelector } from '../../app/hooks';

import { selectCart } from '../../app/reducers/cartSlice';
import { selectUser } from '../../app/reducers/userSlice';

import { Link } from 'react-router-dom';
import { HeaderWrapper, IconLinks, Profile, Logo, MenuList, SearchForm, SubMenuList } from './styles';

import logoImage from '../../assets/logo.png';

export default function Header() {
    const cart = useAppSelector(selectCart);
    const user = useAppSelector(selectUser);
    const session = user ? true : false;

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
                    <IoMdPerson size="30" />
                    {session 
                        ? <Link to='/'>Acessar conta</Link>
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

            {/* <SubMenuList>
                <nav>
                    <Link to='/'>TODOS OS DEPARTAMENTOS</Link>
                    <Link to='/'>LANÇAMENTOS</Link>
                    <Link to='/'>DESTAQUES</Link>
                    <Link to='/'>PC GAMER</Link>
                    <Link to='/'>ELETRÔNICOS</Link>
                    <Link to='/'>SEJA PRIME</Link>
                </nav>
            </SubMenuList> */}
        </HeaderWrapper>
    )
}