import styled from "styled-components";


export const CartTitle = styled.h1`
    margin: 0 0 20px 5px;
    font-size: 1.3rem;
`;

export const CartWrapper = styled.div`
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

export const CartTable = styled.table`
    width: 100%;

    tr {
        display: grid;
        grid-template-columns: 2fr 6fr 2fr 2fr 2fr;
        text-align: center;
        gap: 5%;
        padding: 10px 0;

        th {
            &:nth-child(2) {
                text-align: left;
            }
        }

        td {
            max-height: 100px;

            &:nth-child(2) {
                text-align: left;
            }
        }
    }
`;

export const CartBottom = styled.div`
    display: flex;
    flex-direction: column;
    align-items: flex-end;
    gap: 40px;
    margin-right: 20px;
`;

export const CartFinishButton = styled.button`
    padding: 10px 20px;
    border-radius: 5px;
    border: none;
    color: ${props => props.theme.backgroundLightColor};
    background-color: ${props => props.theme.primaryDarkColor};
`;