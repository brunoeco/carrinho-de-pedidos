import styled from "styled-components";


export const FavoriteWrapper = styled.div`
    display: grid;
    grid-template-columns: 0.1fr 0.6fr 0.2fr 0.1fr;    
    align-items: center;
    gap: 10px;
    padding-bottom: 10px;
    border-bottom: 1px solid #cccccc;

    img {
        width: 100%;
    }

    span {
        justify-self: center;
    
        svg {
            cursor: pointer
        }
    }
`;