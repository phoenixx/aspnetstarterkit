import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import DashboardContainer from '../containers/DashboardContainer';
import Loading from '../components/Loading';

const routes = (
    <Router history={hashHistory}>
        <Route path="/" component={Home}>
            <IndexRoute component={DashboardContainer}/>
            <Route path="loading" component={Loading} />
        </Route>
    </Router>
); 

export default routes;