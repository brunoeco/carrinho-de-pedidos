import styled from "styled-components";

export const HeaderWrapper = styled.div`
    background-color: #FFFFFF;
    box-shadow: 1px 1px 3px rgba(0,0,0, 0.2)
`;

export const Logo = styled.img`
    width: 90%;
`;

export const MenuList = styled.div`
    display: grid;
    grid-template-columns: 2fr 6fr 2fr 2fr;
    align-items: center;
    gap: 4vw;
    margin: 0 7vw;
    height: 80px;
    color: #ACFC7F;


    a {
        font-size: 0.9rem;
        font-family: 'Roboto', sans-serif;
        font-weight: 700;
        text-decoration: none;
        color: #ACFC7F; 
    }
`;

export const SearchForm = styled.form`
    position: relative;

    input {
        width: 100%;
        height: 34px;
        border: none;
        border-radius: 20px;
        padding-left: 15px;
        padding-right: 40px;

        background-color: #F8F8F8;
    }

    button {
        position: absolute;
        right: 15px;
        width: 34px;
        height: 34px;

        border: none;
        background: transparent;

        cursor: pointer;
    }
`;

export const Profile = styled.div`
    display: flex;
    align-items: center;
    gap: 5px;
`;

export const IconLinks = styled.div`
    position: relative;
    display: flex;
    justify-content: flex-end;
    align-items: center;
    gap: 35px;

    span {
        position: absolute;
        top: -5px;
    }
`

export const SubMenuList = styled.div`
    height: 37px;
    background-color: #ff6500; 

    nav {
        display: flex;
        justify-content: space-between;
        align-items: center;

        margin: 0 7vw;
        height: 100%;

        a {
            font-size: 0.9rem;
            font-family: 'Roboto', sans-serif;
            font-weight: 700;
            text-decoration: none;
            color: #ffffff;
        }
    }

`;