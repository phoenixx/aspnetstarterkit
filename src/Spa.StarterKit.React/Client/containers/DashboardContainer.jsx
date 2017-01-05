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
            shippedRadials: null,
            allocationByCarrierService: null,
            startDate: null,
            endDate: null
        }
        this._setTab = this._setTab.bind(this);
        this._reloadData = this._reloadData.bind(this);
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            this.setState({
                hasLoaded: true,
                preDespatchOverviewData: data.data.preDespatchOverviewBarChart,
                allocatedCarriersData: data.data.allocatedCarriersBarChart,
                allocatedCarrierServicesData: data.data.allocatedCarrierServicesBarChart,
                radials: data.data.issuesRadialCharts,
                shippedRadials: data.data.postDespatchRadialCharts,
                allocationByCarrierService: data.data.allocationByCarrierService,
                startDate: data.data.startDate,
                endDate: data.data.endDate
            });
        }).then(() => {
            console.log(this.state);
        });
    }
    _reloadData(start, end) {
        this.setState({
                hasLoaded: false
            },
            () => {
                getDashboardData(start, end).then((data) => {
                    this.setState({
                        hasLoaded: true,
                        preDespatchOverviewData: data.data.preDespatchOverviewBarChart,
                        allocatedCarriersData: data.data.allocatedCarriersBarChart,
                        allocatedCarrierServicesData: data.data.allocatedCarrierServicesBarChart,
                        radials: data.data.issuesRadialCharts,
                        shippedRadials: data.data.postDespatchRadialCharts,
                        allocationByCarrierService: data.data.allocationByCarrierService,
                        startDate: data.data.startDate,
                        endDate: data.data.endDate
                    });
                }).then(() => {
                    console.log(this.state);
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
                shippedRadials={this.state.shippedRadials}
                allocationByCarrierService={this.state.allocationByCarrierService}
                startDate={this.state.startDate}
                endDate={this.state.endDate}
                reload={this._reloadData}
                       />
        );
    }
}

const getDashboardData = (start, end) => {

    let baseUrl = '/dashboard/predespatch';

    if (start) {
        baseUrl = `${baseUrl}?from=${start}`;
    }

    if (end) {
        let separator = '&';
        if (!start) {
            separator = '?';
        }

        baseUrl = `${baseUrl}${separator}to=${end}`;
    }

    console.log('getting data from: ', baseUrl);

    return axios.get(baseUrl)
    .then(function(dashboardResponse) {
            console.log(dashboardResponse);
        return dashboardResponse;
    });
}

export default DashboardContainer;