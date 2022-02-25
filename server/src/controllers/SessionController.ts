import { Request, Response } from "express";
import { fakeDb } from "../fakeDb";
import { UserGetProps, UserType } from "../types";

export default {
    create (req:Request<{},any,any,UserGetProps>, res: Response) {
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
    }
}