import axios from 'axios';

export const connection = axios.create({
    baseURL: "https://localhost:5001/api/",
})