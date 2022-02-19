import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { connection } from '../../api/connection';
import { useAppDispatch } from '../../app/hooks';
import { login } from '../../app/reducers/userSlice';
import { Container } from '../../GlobalStyles';
import { IUser } from '../../models/Users';

export default function Login() {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    
    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const response = await connection.get('login', {
            params: {
                username,
                password
            }
        });
        
        if(response.data.error) {
            alert(response.data.error);
            return;
        }

        const user:IUser = response.data;

        dispatch(login(user));
        navigate('/');
    };

    return (
        <Container>
            <form onSubmit={handleLogin} >
                <label htmlFor="username">Usuário</label>
                <input 
                    type="text" 
                    name="username"
                    id="username" 
                    value={username}
                    onChange={e => setUsername(e.target.value)}
                />

                <label htmlFor="password">Senha</label>
                <input 
                    type="password" 
                    name="password" 
                    id="password" 
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                />

                <button>Entrar</button>
            </form>
        </Container>
    );
}