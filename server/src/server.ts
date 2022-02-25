import express, { Request } from 'express';
import cors from 'cors';
import { fakeDb } from './fakeDb';
import { UserGetProps, UserType } from './types';
import routes from './routes';

const app = express();

app.use(cors())

app.use(routes);

app.listen(3333);