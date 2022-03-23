import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { IFavorite } from '../../../models/Favorite';
import { RootState } from '../../store';

const initialState: Array<IFavorite> = [];

export const favoritesSlice = createSlice({
    name: 'favorites',
    initialState: initialState,
    reducers: {
        changeFavorites: (state, action: PayloadAction<IFavorite[]>) => {
            return [
                ...action.payload
            ];
        },

        addFavorites: (state, action: PayloadAction<IFavorite>) => {
            return [
                ...state,
                action.payload
            ];
        },

        removeFavorites: (state, action: PayloadAction<number>) => {
            const tempState = state.filter(favorite => favorite.id !== action.payload);

            return [...tempState];
        }
    }
});

export const { changeFavorites, removeFavorites, addFavorites } = favoritesSlice.actions;

export const selectFavorites = (state: RootState) => state.favorites;

export default favoritesSlice.reducer;