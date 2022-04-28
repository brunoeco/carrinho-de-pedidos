import * as React from 'react';
import { render as RenderTpl } from '@testing-library/react';

import { Provider } from 'react-redux';
import { store } from '../app/store';
import { BrowserRouter } from 'react-router-dom';


export const render = (component: JSX.Element) => RenderTpl(
    <Provider store={store}>
        <BrowserRouter>
            {component}
        </BrowserRouter>
    </Provider>
)