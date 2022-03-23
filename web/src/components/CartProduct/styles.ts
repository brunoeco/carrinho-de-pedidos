import styled from "styled-components";


export const CartProductWrapper = styled.tr`
    border-bottom: 1px solid #cccccc;

    td:not(:nth-child(2)) {
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
`;

export const ProductImage = styled.img`
    width: 100%;
    height: 100%;
    object-fit: contain;
`;

export const ProductDescription = styled.td`
    h2 {
        font-size: 1.1rem;
        margin-bottom: 10px;
    }

    p {
        font-size: 0.9rem;
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        overflow: hidden;
        text-overflow: ellipsis;
    }
`;

export const AddProduct = styled.div`
    display: flex;
    justify-content: center;
    gap: 5px;
    margin-bottom: 5px;
`;

export const AddButton = styled.button`
    border: none;
    background: transparent;
`;

export const RemoveButton = styled.button`
    border: none;   
    background: transparent;
    color: red;
`;