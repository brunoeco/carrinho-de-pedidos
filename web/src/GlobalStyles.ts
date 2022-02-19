import styled, { createGlobalStyle } from "styled-components"; 

export const GlobalStyles = createGlobalStyle`
    *, body {
        margin: 0;
        body: 0;
        font-family: 'Roboto', sans-serif;
    }

    html, body {
        background-color: #F8F8F8;
        height: 100%;
    }
`;

export const Container = styled.main`
    margin: 50px 7vw 0 7vw;
`;