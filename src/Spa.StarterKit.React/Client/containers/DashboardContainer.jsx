import React from 'react';
import axios from 'axios';
import {
    Layout,
    Header,
    HeaderRow,
    Navigation,
    Drawer,
    Content,
    Grid,
    Cell,
    Card,
    Footer,
    FooterSection,
    FooterDropDownSection,
    FooterLinkList, Tabs, Tab } from 'react-mdl';
import Loading from '../components/Loading';
import {Doughnut, HorizontalBar, Line, Polar, Bar, Pie} from 'react-chartjs-2';
import '../sass/dashboard.scss';

class DashboardContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeTab: 0,
            hasLoaded: false,
            globalStart: null,
            globalEnd: null,
            data: null,
            preDespatchOverview: null,
            allocatedCarriers: null,
            allocatedCarrierServices: null
        }
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            const overview = transformPreDespatchOverview(data.data);
            const allocatedCarriers = transformAllocatedCarriers(data.data);
            const allocatedCarrierServices = transformAllocatedCarrierServices(data.data);
            this.setState({
                data: data.data,
                hasLoaded: true,
                preDespatchOverview: overview,
                allocatedCarriers: allocatedCarriers,
                allocatedCarrierServices: allocatedCarrierServices
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
                <div>
                    <Tabs activeTab={this.state.activeTab} onChange={(tabId) => this.setState({ activeTab: tabId })} ripple>
                        <Tab>Pre-Despatch</Tab>
                        <Tab>Post-Despatch</Tab>
                    </Tabs>
                    {this.state.activeTab === 0 ? (
                    <Grid>
                        <Cell col={6}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                              <Line data={this.state.preDespatchOverview} height={100} options={{maintainAspectRatio: false}} />
                            </Card>
                            </Cell>
                            <Cell col={6}>
                                <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                                            <HorizontalBar data={this.state.allocatedCarriers} options={{maintainAspectRatio: false}} />
                            </Card>
                            </Cell>
                            <Cell col={12}>
                                <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                                            <HorizontalBar data={this.state.allocatedCarrierServices} height={100} options={{maintainAspectRatio: false}} />
                            </Card>
                            </Cell>
                        </Grid>
                    ) : (
                        <div>post, bitch</div>
                    )}
                    
                </div>
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

//TODO abstract into reusable utility funtions
function transformPreDespatchOverview(inputData) {
    const source = inputData.preDespatchOverviewBarChart;
    const labels = source.map(item => {
        return item.name;
    });
    const datapoints = source.map(item => {
        return item.value;
    });
    const chartSourceData = {
        labels: labels,
        datasets: [
          {
              label: 'Status',
              fill: true,
              lineTension: 0.5,
              backgroundColor: 'rgba(75,192,192,0.4)',
              borderColor: 'rgba(75,192,192,1)',
              borderCapStyle: 'butt',
              borderDash: [],
              borderDashOffset: 0.0,
              borderJoinStyle: 'miter',
              pointBorderColor: 'rgba(75,192,192,1)',
              pointBackgroundColor: '#fff',
              pointBorderWidth: 1,
              pointHoverRadius: 5,
              pointHoverBackgroundColor: 'rgba(75,192,192,1)',
              pointHoverBorderColor: 'rgba(220,220,220,1)',
              pointHoverBorderWidth: 2,
              pointRadius: 6,
              pointHitRadius: 40,
              data: datapoints,
              legend: false
          }]
    }

    return chartSourceData;
}

function transformAllocatedCarriers(inputData) {
    const source = inputData.allocatedCarriersBarChart;
    const labels = source.map(item => {
        return item.name;
    });
    const data = source.map(item => {
        return item.value;
    });

    const allocatedCarriersBarData = {
        labels: labels,
        datasets:
        [
            {
                label: 'Allocated Carriers',
                backgroundColor: 'rgba(255,99,132,0.2)',
                borderColor: 'rgba(255,99,132,1)',
                borderWidth: 1,
                hoverBackgroundColor: 'rgba(255,99,132,0.4)',
                hoverBorderColor: 'rgba(255,99,132,1)',
                data: data
            }
        ]
    };

    return allocatedCarriersBarData;

}

function transformAllocatedCarrierServices(inputData) {
    const source = inputData.allocatedCarrierServicesBarChart;
    const labels = source.map(item => {
        return item.name;
    });
    const data = source.map(item => {
        return item.value;
    });

    const allocatedCarrierServicesBarData = {
        labels: labels,
        datasets:
        [
            {
                label: 'Allocated Carrier Services',
                backgroundColor: 'rgba(255,99,132,0.2)',
                borderColor: 'rgba(255,99,132,1)',
                borderWidth: 1,
                hoverBackgroundColor: 'rgba(255,99,132,0.4)',
                hoverBorderColor: 'rgba(255,99,132,1)',
                data: data
            }
        ]
    };

    return allocatedCarrierServicesBarData;

}

export default DashboardContainer;