import React from 'react';
import { useAppSelector } from '../../app/hooks';
import { selectCart } from '../../app/reducers/cartSlice';
import CartProduct from '../../components/CartProduct';
import { Container } from '../../GlobalStyles';

export default function Cart() {
    const cart = useAppSelector(selectCart);

    return (
        <Container>
            <h1>Carrinho</h1>

            {cart.length > 0 
                ? cart.map(product => (
                    <CartProduct key={product.id} {...product} />
                ))
                : <h3>Nenhum produto no carrinho.</h3>
            }
        </Container>
    )
}