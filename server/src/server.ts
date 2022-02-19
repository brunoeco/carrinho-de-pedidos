import express, { Request } from 'express';
import cors from 'cors';
import { fakeDb } from './fakeDb';
import { UserGetProps, UserType } from './types';

const app = express();

app.use(cors())

app.get('/products', (req, res) => {
    const products = fakeDb.products;

    return res.json(products);
});

app.get('/login', (req:Request<{},any,any,UserGetProps>, res) => {
    const user: UserType = fakeDb.users.find(user => 
        user.username === req.query.username && user.password === req.query.password
    );


    if(!user) {
        return res.status(401).json({ error: "Usuário ou senha incorretos" });
    }

    return res.json({
        id: user.id,
        name: user.name,
        username: user.username
    });
})

app.listen(3333);