export type UserType = {
    id: number;
    name: string;
    username: string;
    password: string;
} | undefined;

export type UserGetProps = {
    username: string;
    password: string;
}