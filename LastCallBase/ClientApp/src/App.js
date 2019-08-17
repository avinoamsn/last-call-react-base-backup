import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { RegisterSubscriber } from './components/RegisterSubscriber';
import { RegisterSupplier } from './components/RegisterSupplier';
import { BaseService } from './components/BaseService';
import { PostService } from './components/PostSample';
import { FetchSubscriberAndPreferences } from './components/FetchSubscriberAndPreferences';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/mealoffers' component={FetchData} />
            <Route path='/registersubscriber' component={RegisterSubscriber} />
            <Route path='/registersupplier' component={RegisterSupplier} />
            <Route path='/baseservice' component={BaseService} />
            <Route path='/postservice' component={PostService} />
            <Route path='/fetchsubscriberandpreferences' component={FetchSubscriberAndPreferences} />
      </Layout>
    );
  }
}
