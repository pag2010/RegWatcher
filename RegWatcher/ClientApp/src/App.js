import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import RegMenu from './components/RegMenu';
import Home from './components/Home';
import Login from './components/Login';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Registration from './components/Registration';
import ConfirmUser from './components/ConfirmUser';

export default () => (
  <Layout>
        <Route exact path='/Account/Login' component={Login} />
        <Route exact path='/Account/Registration' component={Registration} />
        <Route exact path='/' component={Home} />
        <Route exact path='/Home' component={Home} />
        <Route exact path='/Account/ConfirmUser' component={ConfirmUser} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
