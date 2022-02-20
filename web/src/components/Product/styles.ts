import styled from "styled-components";


export const ProductWrapper = styled.div`
    position: relative;
    border-radius: 5px;
    background-color: ${props => props.theme.backgroundLightColor}; 

    box-shadow: 2px 2px 4px 1px rgba(0,0,0,0.1)
`;

export const ProductInfo = styled.div`
    margin: 10px;
`;

export const FavoriteProduct = styled.div`
    display: flex;
    justify-content: flex-end;

    span {
        cursor: pointer;
    }
`;

export const ProductImage = styled.img`
    width: 100%;
    height: 150px;
    margin: 10px 0;
    object-fit: contain;
`;

export const ProductDescription = styled.div`
    padding-bottom: 35px;

    h2 {
        margin: 0;
        margin-bottom: 20px;
        height: 50px;
        font-size: 1rem;

        display: -webkit-box;
        -webkit-line-clamp: 3;
        -webkit-box-orient: vertical;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    span {
        display: flex;
        heigth: 100%;
        font-size: 1.5rem;
        font-weight: 700;
        color: ${props => props.theme.primaryDarkColor};
    }
`;

export const AddCartButton = styled.button`

    display: flex;
    align-items: center;
    justify-content: center;
    gap: 10px;
    padding: 5px 15px;

    border: none;
    border-radius: 5px;
    background-color: ${props => props.theme.primaryDarkColor};
    color: #fff;
    font-weight: 700;

    transition: 0.3s ease;
    
    cursor: pointer;

    :hover {
        filter: brightness(90%);
    }
`;