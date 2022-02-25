import React from 'react';

import logoImage from '../../assets/logo.png';
import { FooterWrapper } from './styles';

export default function Footer() {
    return (
        <FooterWrapper>
            <img src={logoImage} alt="logo" />
        </FooterWrapper>
    )
}