import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IUser } from '../../../models/User';
import { RootState } from '../../store';

export function getUser() {
    const user = localStorage.getItem('userRMT');

    if(user){
        const userParsed: IUser = JSON.parse(user);

        return userParsed;
    }

    return null;
}

const cacheItems = getUser();

const initialState: IUser | null = cacheItems ? cacheItems : null;

export const userSlice = createSlice({
    name: 'user',
    initialState: initialState,
    reducers: {
        login: (state, action: PayloadAction<IUser>) => {
            localStorage.setItem('userRMT', JSON.stringify(action.payload));
            return action.payload;
        },

        logout: (state) => {
            localStorage.removeItem('userRMT');
            return initialState;
        },
    }
});

export const { login, logout } = userSlice.actions;

export const selectUser = (state: RootState) => state.user;

export default userSlice.reducer;