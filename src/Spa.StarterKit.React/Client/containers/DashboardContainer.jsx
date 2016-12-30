import React from 'react';
import axios from 'axios';
import Dashboard from '../components/Dashboard';

class DashboardContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeTab: 0,
            hasLoaded: false,
            globalStart: null,
            globalEnd: null,
            preDespatchOverviewData: null,
            allocatedCarriersData: null,
            allocatedCarrierServicesData: null,
            radials: null,
            allocationByCarrierService: null
        }
        this._setTab = this._setTab.bind(this);
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            this.setState({
                hasLoaded: true,
                preDespatchOverviewData: data.data.preDespatchOverviewBarChart,
                allocatedCarriersData: data.data.allocatedCarriersBarChart,
                allocatedCarrierServicesData: data.data.allocatedCarrierServicesBarChart,
                radials: data.data.issuesRadialCharts,
                allocationByCarrierService: data.data.allocationByCarrierService
            });
        });
    }
    _setTab(tabId) {
        this.setState({
            activeTab: tabId
        });
    }
    render() {
        return(
            <Dashboard 
                hasLoaded={this.state.hasLoaded}
                activeTab={this.state.activeTab}
                setActiveTab={this._setTab}
                preDespatchOverviewData={this.state.preDespatchOverviewData}
                allocatedCarriersData={this.state.allocatedCarriersData}
                allocatedCarrierServicesData={this.state.allocatedCarrierServicesData}
                radials={this.state.radials}
                allocationByCarrierService={this.state.allocationByCarrierService}/>
        );
    }
}

const getDashboardData = () => {
    return axios.get('/dashboard/predespatch/')
    .then(function(dashboardResponse) {
            console.log(dashboardResponse);
        return dashboardResponse;
    });
}

export default DashboardContainer;