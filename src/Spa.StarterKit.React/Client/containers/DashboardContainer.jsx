import React from 'react';
import axios from 'axios';
import Loading from '../components/Loading';

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
            this.state.hasLoaded === false ? (
                <Loading />
            )
            :
            (
                <div>loaded</div>
            )
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