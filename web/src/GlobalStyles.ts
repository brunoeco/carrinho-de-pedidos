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

    .message {
        text-align: center;
        margin: 50px 0;
    }

`;

export const Container = styled.main`
    margin: 50px 7vw 50px 7vw;
`;

export const Title = styled.h1`
    margin: 0 0 20px 5px;
    font-size: 1.3rem;
`;

export const Wrapper = styled.div`
    display: flex;
    flex-direction: column;
    gap: 10px;
    background-color: ${props => props.theme.backgroundLightColor};
    border-radius: 10px;
    box-shadow: 2px 2px 4px 1px rgba(0,0,0,0.2);
    width: 100%;
    padding: 2%; 
    margin-bottom: 20px;

    button {
        cursor: pointer;

        :hover {
            filter: brightness(90%);
        }
    }
`;
