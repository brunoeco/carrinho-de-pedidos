import styled, { createGlobalStyle } from "styled-components"; 

export const GlobalStyles = createGlobalStyle`
    *, body {
        margin: 0;
        padding: 0;
        font-family: 'Roboto', sans-serif;
    }

    html, body, #root {
        background-color: #F8F8F8;
        height: 100vh
    }

    #root {
        display: flex;
        flex-direction: column;
    }

`;

export const Container = styled.main`
    margin: 50px 7vw 50px 7vw;
`;