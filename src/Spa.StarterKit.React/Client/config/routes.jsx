import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import Sample from '../components/Sample';
import DashboardContainer from '../containers/DashboardContainer';

const routes = (
    <Router history={hashHistory}>
        <Route path="/" component={Home}>
            <IndexRoute component={DashboardContainer}/>
        </Route>
    </Router>
); 

export default routes;