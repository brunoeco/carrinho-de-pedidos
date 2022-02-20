import React from 'react';

export default function Sidebar() {
    return (
        <div>
            <h4>Filtrar por:</h4>

            <form>
                <div>
                    <span>Preço</span>
                    <div>
                        <label htmlFor="price-min">Min.</label>
                        <input type="number" name="price-min" id="price-min" />
                    </div>
                    <div>                        
                        <label htmlFor="price-min">Max.</label>
                        <input type="number" name="price-max" id="price-max" />
                    </div>
                </div>

                <div>
                    <span>Categorias</span>
                    <div>
                        <input type="radio" name="productType" id="todos" />
                        <label htmlFor="todos">Todos</label>
                    </div>
                    <div>
                        <input type="radio" name="productType" id="celular" />
                        <label htmlFor="celular">Celular</label>
                    </div>
                    <div>
                        <input type="radio" name="productType" id="computador" />
                        <label htmlFor="computador">Computador</label>
                    </div>
                        <div>
                            
                        <input type="radio" name="productType" id="acessorios" />
                        <label htmlFor="acessorios">Acessórios</label>
                    </div>
                    <div>
                        <input type="radio" name="productType" id="componentes" />
                        <label htmlFor="componentes">Componentes</label>
                    </div>
                </div>
            </form>
        </div>
    )
}