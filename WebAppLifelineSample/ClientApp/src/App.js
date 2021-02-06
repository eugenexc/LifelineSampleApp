import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Customer } from './components/Customer';
import { CustomerDetail } from './components/CustomerDetail';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/customer' component={Customer} />
            <Route path="/customer-detail/:id" component={CustomerDetail} />
      </Layout>
    );
  }
}
