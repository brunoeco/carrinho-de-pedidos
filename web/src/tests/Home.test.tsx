import React from 'react';
import { screen } from '@testing-library/react';

import Home from '../pages/Home';
import { render } from './render';

test('Deve conter o título: Home', () => {
    render(<Home />);

    expect(screen.getByText('Home')).toBeInTheDocument();
})