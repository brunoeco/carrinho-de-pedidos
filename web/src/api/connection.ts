import axios from 'axios';

export const baseURL = "https://localhost:44318/"

export const connection = axios.create({
    baseURL: `${baseURL}api/`,
})