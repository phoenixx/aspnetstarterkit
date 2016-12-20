import React from 'react';
import axios from 'axios';


class DashboardContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            hasLoaded: false,
            globalStart: null,
            globalEnd: null,
            data: null
        }
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            this.setState({
                data: data,
                hasLoaded: true
            });
        });
        
    }
    render() {
        return (
            <div>{this.state.hasLoaded === true ? 'loaded' : 'not loaded'}</div>
        );
    }
}

function getDashboardData() {
    return axios.get('/dashboard/predespatch/')
    .then(function(dashboardResponse) {
        console.log(dashboardResponse);
        return dashboardResponse;
    });
}

export default DashboardContainer;