import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import DashboardContainer from '../containers/DashboardContainer';
import Loading from '../components/Loading';
import { IntlProvider } from 'react-intl';

const routes = (
    <IntlProvider locale={'en-GB'}>
        <Router history={hashHistory}>
        <Route path="/" component={Home}>
            <IndexRoute component={DashboardContainer} />
            <Route path="loading" component={Loading} />
        </Route>
        </Router>
    </IntlProvider>
    
); 

export default routes;