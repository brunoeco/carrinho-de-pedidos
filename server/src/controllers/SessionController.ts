import { Request, Response } from "express";
import { fakeDb } from "../fakeDb";
import { UserGetProps, UserType } from "../types";

export default {
    create (req:Request<{}, any, UserGetProps, any>, res: Response) {
        const { username, password } = req.body;

        const user: UserType = fakeDb.users.find(user => 
            user.username === username && user.password === password
        );
    
    
        if(!user) {
            return res.status(401).json({ error: "Usuário ou senha incorretos" });
        }
    
        return res.json({
            id: user.id,
            name: user.name,
            username: user.username
        });
    }
}