import React from 'react';
import { useAppSelector } from '../../app/hooks';
import { selectCart } from '../../app/reducers/cartSlice';
import CartProduct from '../../components/CartProduct';
import { Container, Title, Wrapper } from '../../GlobalStyles';
import { CartTable, CartBottom, CartFinishButton } from './styles';

export default function Cart() {
    const cart = useAppSelector(selectCart);

    const total = cart.reduce((total, cart) => total + (cart.price * cart.quantity), 0);

    return (
        <Container>
            <Title>Carrinho de Pedidos</Title>
            
            <Wrapper>
                {cart.length > 0 ?
                    <>
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
                                {cart.map(product => (
                                        <CartProduct key={product.id} {...product} />
                                    ))}
                            </tbody>
                        </CartTable>

                        
                        <CartBottom>
                            <p>Total: R$ {total.toFixed(2)}</p>

                            <CartFinishButton>Finalizar pedido</CartFinishButton>
                        </CartBottom>
                    </>
                    
                    : <p className="message">Nenhum produto no carrinho.</p>
                }

            </Wrapper>
        </Container>
    )
}