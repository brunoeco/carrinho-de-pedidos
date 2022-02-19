import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState } from '../../store';
import { FilterState, PriceType } from '../types';

const initialState: FilterState = {
    category: [],
    price: {
        start: 0,
        end: 50000,
    }
};

export const filterSlice = createSlice({
    name: 'cart',
    initialState: initialState,
    reducers: {
        addCategory: (state, action: PayloadAction<string>) => {
            const categoryExists = state.category.find(category => (
                category === action.payload
            ));

            if(categoryExists) return { ...state };
            
            
            return {
                ...state,
                category: [
                    ...state.category,
                    action.payload
                ]
            };
        },
        removeCategory: (state, action: PayloadAction<string>) => {
           const categoryExists = state.category.filter(category => (
                category !== action.payload
            ));

            return {
                ...state,
                category: [
                    ...categoryExists
                ]
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

export const { addCategory, removeCategory, changePrice } = filterSlice.actions;

export const selectFilter = (state: RootState) => state.filter;

export default filterSlice.reducer;