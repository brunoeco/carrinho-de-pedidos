import { configureStore } from '@reduxjs/toolkit';
import filterReducer from './reducers/filterSlice';
import cartReducer from './reducers/cartSlice';
import userReducer from './reducers/userSlice';

export const store = configureStore({
    reducer: {
        filter: filterReducer,
        cart: cartReducer,
        user: userReducer
    }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;