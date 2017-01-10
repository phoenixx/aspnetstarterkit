import React , { Component }from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import DashboardContainer from '../containers/DashboardContainer';
import Loading from '../components/Loading';
import ConsignmentsContainer from '../containers/ConsignmentsContainer';
import { IntlProvider } from 'react-intl';

class RouteComponent extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <IntlProvider locale={'en-GB'}>
                <Router history={hashHistory}>
                    <Route path="/" component={Home}>
                        <IndexRoute component={DashboardContainer}/>
                        <Route path="loading" component={Loading}/>
                        <Route path="shipped" consignmentState="shipped" component={ConsignmentsContainer}/>
                        <Route path="notshipped" consignmentState="notshipped" component={ConsignmentsContainer} />
                    </Route>
                </Router>
            </IntlProvider>
        );
    }
}

//const routes = (
//    <IntlProvider locale={'en-GB'}>
//        <Router history={hashHistory}>
//        <Route path="/" component={Home}>
//            <IndexRoute component={DashboardContainer} />
//            <Route path="loading" component={Loading} />
//            <Route path="shipped" consignmentState="shipped" component={ConsignmentsContainer}/>
//        </Route>
//        </Router>
//    </IntlProvider>
    
//); 

export default RouteComponent;