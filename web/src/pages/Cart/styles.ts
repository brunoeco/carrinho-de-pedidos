import styled from "styled-components";

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
    gap: 30px;
    margin-right: 20px;
    margin-top: 20px;
`;

export const CartFinishButton = styled.button`
    padding: 10px 20px;
    border-radius: 5px;
    border: none;
    color: ${props => props.theme.backgroundLightColor};
    background-color: ${props => props.theme.primaryDarkColor};
    font-weight: 700;
`;