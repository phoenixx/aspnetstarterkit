import React , { Component }from 'react';
import { Router, Route, hashHistory, IndexRoute } from 'react-router';
import Home from '../components/Home';
import DashboardContainer from '../containers/DashboardContainer';
import Loading from '../components/Loading';
import ConsignmentsContainer from '../containers/ConsignmentsContainer';
import ConsignmentContainer from '../containers/ConsignmentContainer';
import RouteNotFound from '../components/404';
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
                        <Route path="/notshipped">
                            <IndexRoute component={ConsignmentsContainer} consignmentState="notshipped"/>
                            <Route path=":consignmentSubState" consignmentState="notshipped" component={ConsignmentsContainer}/>
                        </Route>
                        <Route path="/consignment">
                            <Route path=":consignmentReference" component={ConsignmentContainer} />
                        </Route>
                        <Route path="*" component={RouteNotFound}/>
                    </Route>
                </Router>
            </IntlProvider>
        );
    }
}

export default RouteComponent;