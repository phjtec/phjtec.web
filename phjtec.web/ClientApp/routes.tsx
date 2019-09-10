import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { Services } from './components/Services';
import { ServiceDetail } from './components/ServiceDetail';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/our-services' component={Services} />
    <Route path='/we-provide/:serviceRoute' component={ServiceDetail} />
</Layout>;
