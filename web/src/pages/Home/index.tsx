import { Pagination } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { connection } from '../../api/connection';
import { useAppSelector } from '../../app/hooks';
import { selectFilter } from '../../app/reducers/filterSlice';
import Product from '../../components/Product';

import SideBar from '../../components/SideBar';
import { Container } from '../../GlobalStyles';
import { IProduct } from '../../models/Products';
import { HomeWrapper, PaginationButtons, ProductsListWrapper } from './styles';

export default function Home() {
    const [products, setProducts] = useState<Array<IProduct>>([]);
    const [ page, setPage ] = useState<number>(0);

    const itensPerPage = 6;
    const pages = Math.ceil(products.length / itensPerPage);
    const startIndex = page * itensPerPage;
    const endIndex = startIndex + itensPerPage;
    const currentItens = products.slice(startIndex, endIndex);

    const filter = useAppSelector(selectFilter);

    const search = `search=${filter.search}`;
    const category = `category=${filter.category}`;
    const minPrice = `min_price=${filter.price.min}`;
    const maxPrice = filter.price.max ? `max_price=${filter.price.max}` : '';

    const url = `products?${category}&${minPrice}&${maxPrice}&${search}`;

    useEffect(() => {
        connection.get(url).then(response => {
            setPage(0);
            setProducts(response.data);
        }).catch(err => {
            console.log(err);
        });;
    }, [url])

    return(
        <Container>
            <HomeWrapper>
                <SideBar />
                <div>
                    <PaginationButtons>
                        <Pagination     
                            count={pages}
                            onChange={(e, value) => 
                            setPage(Number(value) - 1)} 
                        />
                    </PaginationButtons>
                    <ProductsListWrapper>
                        {currentItens.map((product) => (
                            <Product key={product.id} {...product} />
                        ))}
                    </ProductsListWrapper>
                </div>
            </HomeWrapper>
        </Container>
    );
}