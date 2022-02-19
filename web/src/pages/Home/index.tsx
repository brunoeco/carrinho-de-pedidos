import React, { useEffect, useState } from 'react';
import { connection } from '../../api/connection';
import Product from '../../components/Product';

import SideBar from '../../components/SideBar';
import { Container } from '../../GlobalStyles';
import { IProduct } from '../../models/Products';
import { HomeWrapper, ProductsListWrapper } from './styles';

export default function Home() {
    const [products, setProducts] = useState<Array<IProduct>>([]);

    useEffect(() => {
        connection.get('products').then(response => {
            setProducts(response.data);
        });
    }, [])

    return(
        <Container>
            <HomeWrapper>
                <SideBar />
                <ProductsListWrapper>
                    {products.map((product) => (
                        <Product key={product.id} {...product} />
                    ))}
                </ProductsListWrapper>
            </HomeWrapper>
        </Container>
    );
}