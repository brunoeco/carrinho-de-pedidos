import styled from 'styled-components';

export const HomeWrapper = styled.div`
    display: grid;
    grid-template-columns: 3fr 9fr;
    gap: 3vw;
`;

export const ProductsListWrapper = styled.div`
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    gap: 15px;

    width: 100%;
`;