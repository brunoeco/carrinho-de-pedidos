import { render as RenderTpl } from '@testing-library/react';

import { Provider } from 'react-redux';
import { store } from '../app/store';


export const render = (component: JSX.Element) => RenderTpl(
    <Provider store={store}>
        {component}
    </Provider>
)