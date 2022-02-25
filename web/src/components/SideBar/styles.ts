import styled from "styled-components";


export const FilterTitle = styled.h4`
    margin: 0 0 20px 5px;
`;

export const FilterForm = styled.form`
    padding: 5%;
    border-radius: 5px;
    background-color: ${props => props.theme.backgroundLightColor};

`;

export const Price = styled.div`
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 20%;
    width: 80%;

    margin: 10px 0 20px 0;

    input {
        width: 90%;
    }
`;

export const Category = styled.div`
    margin: 10px 0 20px 0;

    div {
        display: flex;
        gap: 10px;
    }

`;