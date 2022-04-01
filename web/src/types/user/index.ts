import { IUser } from "../../models/User";

export interface ILoginResponse {
    user: IUser;
    token: string;
}