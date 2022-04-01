import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { connection } from '../../api/connection';
import { useAppDispatch } from '../../app/hooks';
import { login } from '../../app/reducers/userSlice';
import { Container } from '../../GlobalStyles';
import { ILoginResponse } from '../../types/user';
import { LoginButton, LoginFields, LoginForm } from './styles';

export default function Login() {
    const [username, setUsername] = useState<string>("");
    const [password, setPassword] = useState<string>("");
    
    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        if(password.trim() === "" || username.trim() === "")
            return alert('Preencha todos os campos.');

        try {
            const response = await connection.post<ILoginResponse>('sessions', {
                username: username,
                password: password
            })
    
            dispatch(login({ 
                ...response.data.user, 
                token: response.data.token
            }));
            navigate('/');
        } catch(err) {
            console.log(err);
            alert('Usuario ou senha incorretos.');
            return;
        }
    };

    return (
        <Container>
            <LoginForm onSubmit={handleLogin} >
                <LoginFields>
                    <label htmlFor="username">Usuário</label>
                    <input 
                        type="text" 
                        name="username"
                        id="username"
                        value={username}
                        onChange={e => setUsername(e.target.value)}
                        required
                    />
                </LoginFields>

                <LoginFields>
                    <label htmlFor="password">Senha</label>
                    <input 
                        type="password" 
                        name="password" 
                        id="password" 
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                        required
                    />
                </LoginFields>

                <LoginButton>Entrar</LoginButton>
            </LoginForm>
        </Container>
    );
}