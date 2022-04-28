import * as React from 'react';
import Header from '../components/Header';
import { screen } from '@testing-library/react';
import { render } from './render';

test('Deve conter "Perfil" como link: ', () => {
    render(<Header />);

    expect(screen.getByText("Faça login")).toBeInTheDocument();
})

test('Deve ser true', () => {
    expect(true).toBe(true);
})