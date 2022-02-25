import React from 'react';
import { useAppSelector } from '../../app/hooks';
import { selectCart } from '../../app/reducers/cartSlice';
import CartProduct from '../../components/CartProduct';
import { Container } from '../../GlobalStyles';
import { CartTable, CartWrapper, CartBottom, CartFinishButton, CartTitle } from './styles';

export default function Cart() {
    const cart = useAppSelector(selectCart);

    const total = cart.reduce((total, cart) => total + (cart.price * cart.quantity), 0);

    return (
        <Container>
            <CartTitle>Carrinho de Pedidos</CartTitle>
            
            <CartWrapper>
                <CartTable>
                    <thead>
                        <tr>
                            <th></th>
                            <th>Descrição</th>
                            <th>Qntd.</th>
                            <th>Preço Unid.</th>
                            <th>Subtotal</th>
                        </tr>
                    </thead>
                    <tbody>
                        {cart.length > 0 
                            ? cart.map(product => (
                                <CartProduct key={product.id} {...product} />
                            ))
                            : <p>Nenhum produto no carrinho.</p>
                        }
                    </tbody>
                </CartTable>

                <CartBottom>
                    <p>Total: R$ {total.toFixed(2)}</p>

                    <CartFinishButton>Finalizar pedido</CartFinishButton>
                </CartBottom>
            </CartWrapper>
        </Container>
    )
}