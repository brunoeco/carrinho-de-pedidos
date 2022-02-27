import styled from "styled-components";


export const LoginForm = styled.form`
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 50px 50px;
    gap: 20px;
    border-radius: 10px;

    background-color: ${props => props.theme.backgroundLightColor};
`;

export const LoginFields = styled.div`
    display: flex;
    flex-direction: column;
    color: #555;
    width: 100%;
    max-width: 300px;

    input {
        height: 32px;
        padding: 0 10px;
        text-align: center;

        border: none;
        border-bottom: 1px solid ${props => props.theme.primaryDarkColor};
        outline: none;

    }

    label {
        align-self: flex-start;
        font-size: 0.8rem;
    }
`;

export const LoginButton = styled.button`
    width: 100%;
    max-width: 280px;
    padding: 5px 0;
    margin-top: 20px;
    font-size: 1rem;
    font-weight: 700;
    color: ${props => props.theme.backgroundLightColor};

    border: none;
    border-radius: 20px;
    background-color:  ${props => props.theme.primaryDarkColor};
    
    cursor: pointer;
`;