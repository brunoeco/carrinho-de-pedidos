import { Router } from 'express';
import ProductController from './controllers/ProductController';
import SessionController from './controllers/SessionController';
const routes = Router();

routes.get('/products', ProductController.index);

routes.get('/login', SessionController.create)

export default routes;