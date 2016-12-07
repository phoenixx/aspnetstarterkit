import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';

const routes = (
    <Router history={hashHistory}>
        <Route path="/" component={Home}>
            <IndexRoute component={Home}/>
        </Route>
    </Router>
); 

export default routes;