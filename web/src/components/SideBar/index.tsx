import React from 'react';
import { useAppDispatch, useAppSelector } from '../../app/hooks';
import { changeCategory, changeMaxPrice, changeMinPrice, selectFilter } from '../../app/reducers/filterSlice';
import { FilterForm, Category, Price, FilterTitle } from './styles';

export default function Sidebar() {
    const filter = useAppSelector(selectFilter);

    const dispatch = useAppDispatch();

    const handleChangeMaxPrice = (value: string) => {
        dispatch(changeMaxPrice(
            value === '' ? null : Number(value)
        ))
    }

    const handleChangeMinPrice = (value: string) => {
        dispatch(changeMinPrice(Number(value)));
    }

    const handleChangeCategory = (value: string) => {
        dispatch(changeCategory(value));
    }

    return (
        <div>
            <FilterTitle>Filtrar por:</FilterTitle>

            <FilterForm>
                <div>
                    <span>Preço</span>
                    
                    <Price>
                        <div>
                            <label htmlFor="min-price">Min.</label>
                            <input 
                                type="number" 
                                name="min-price" 
                                id="min-price" 
                                value={filter.price.min}
                                onChange={(e) => handleChangeMinPrice(e.target.value)}
                            />
                        </div>
                        <div>                        
                            <label htmlFor="min-price">Max.</label>
                            <input 
                                type="number" 
                                name="max-price" 
                                id="max-price" 
                                value={filter.price.max ? filter.price.max : ''}
                                onChange={(e) => handleChangeMaxPrice(e.target.value)}
                            />
                        </div>
                    </Price>
                </div>

                <div>
                    <span>Categorias</span>
                    
                    <Category>
                        <div>
                            <input 
                                type="radio"   
                                name="productType"
                                id="todos" 
                                value="" 
                                onChange={e => handleChangeCategory(e.target.value)}
                            />
                            <label htmlFor="todos">Todos</label>
                        </div>
                        <div>
                            <input 
                                type="radio"   
                                name="productType"
                                id="celulares" 
                                value="celulares" 
                                onChange={e => handleChangeCategory(e.target.value)}
                            />
                            <label htmlFor="celulares">Celular</label>
                        </div>
                        <div>
                            <input 
                                type="radio"   
                                name="productType"
                                id="computadores" 
                                value="computadores" 
                                onChange={e => handleChangeCategory(e.target.value)}
                            />
                            <label htmlFor="computadores">Computador</label>
                        </div>
                        <div>
                            <input 
                                type="radio"   
                                name="productType"
                                id="acessorios" 
                                value="acessorios" 
                                onChange={e => handleChangeCategory(e.target.value)}
                            />
                            <label htmlFor="acessorios">Acessórios</label>
                        </div>
                        <div>
                            <input 
                                type="radio"   
                                name="productType"
                                id="componentes" 
                                value="componentes" 
                                onChange={e => handleChangeCategory(e.target.value)}
                            />
                            <label htmlFor="componentes">Componentes</label>
                        </div>
                    </Category>
                </div>
            </FilterForm>
        </div>
    )
}