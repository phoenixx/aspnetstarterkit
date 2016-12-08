import React from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import Sample from '../components/Sample';

const routes = (
    <Router history={hashHistory}>
        <Route path="/" component={Home}>
            <IndexRoute component={Sample}/>
        </Route>
    </Router>
); 

export default routes;