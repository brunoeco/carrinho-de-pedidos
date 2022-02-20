import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../store';
import { FilterState, PriceType } from '../types';

const initialState: FilterState = {
    category: '',
    price: {
        min: 0,
        max: null,
    }
};

export const filterSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        changeCategory: (state, action: PayloadAction<string>) => {
            return {
                ...state,
                category: action.payload
            };
        },

        changePrice: (state, action: PayloadAction<PriceType>) => {
            
            return {
                ...state,
                price: {
                    ...action.payload
                }
            }
        },
    }
});

export const { changeCategory, changePrice } = filterSlice.actions;

export const selectFilter = (state: RootState) => state.filter;

export default filterSlice.reducer;