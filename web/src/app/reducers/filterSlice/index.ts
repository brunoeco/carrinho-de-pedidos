import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../store';
import { FilterState } from '../types';

const initialState: FilterState = {
    category: '',
    price: {
        min: 0,
        max: null,
    },
    search: '',
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

        changeMinPrice: (state, action: PayloadAction<number>) => {
            
            return {
                ...state,
                price: {
                    ...state.price,
                    min: action.payload
                }
            }
        },

        changeMaxPrice: (state, action: PayloadAction<number | null>) => {
            
            return {
                ...state,
                price: {
                    ...state.price,
                    max: action.payload
                }
            }
        },

        changeSearch: (state, action: PayloadAction<string>) => {
            return {
                ...state,
                search: action.payload
            }
        },
    }
});

export const { changeCategory, changeMinPrice, changeMaxPrice, changeSearch } = filterSlice.actions;

export const selectFilter = (state: RootState) => state.filter;

export default filterSlice.reducer;