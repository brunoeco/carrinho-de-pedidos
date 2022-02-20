import React, { useEffect, useState } from 'react';
import { connection } from '../../api/connection';
import { useAppSelector } from '../../app/hooks';
import { selectFilter } from '../../app/reducers/filterSlice';
import Product from '../../components/Product';

import SideBar from '../../components/SideBar';
import { Container } from '../../GlobalStyles';
import { IProduct } from '../../models/Products';
import { HomeWrapper, ProductsListWrapper } from './styles';

export default function Home() {
    const [products, setProducts] = useState<Array<IProduct>>([]);

    const filter = useAppSelector(selectFilter);

    const category = `category=${filter.category}`;
    const priceMin = `price_min=${filter.price.min}`;
    const priceMax = filter.price.max ? `price_max=${filter.price.max}` : '';

    const url = `products?${category}&${priceMin}&${priceMax}`;

    useEffect(() => {

        connection.get(url).then(response => {
            setProducts(response.data);
        });
    }, [url])

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