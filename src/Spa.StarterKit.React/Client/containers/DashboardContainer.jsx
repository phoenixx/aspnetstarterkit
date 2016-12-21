import React from 'react';
import axios from 'axios';
import {
    Button,
    Content,
    Grid,
    Cell,
    Card,
    CardTitle,
    CardActions,
    Tabs,
    Tab } from 'react-mdl';
import Loading from '../components/Loading';
import {Doughnut, HorizontalBar, Line, Polar, Bar, Pie} from 'react-chartjs-2';
import '../sass/dashboard.scss';
import Utils from '../utilities/utils';

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
            allocatedCarrierServices: null,
            unallocatedRadial: null,
            allocationFailedRadial: null,
            manifestFailedRadial: null
        }
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            const overview = transformPreDespatchOverview(data.data);
            const allocatedCarriers = transformAllocatedCarriers(data.data);
            const allocatedCarrierServices = transformAllocatedCarrierServices(data.data);
            const unallocatedRadial = transformRadial(data.data.issuesRadialCharts, 'Unallocated');
            const allocationFailed = transformRadial(data.data.issuesRadialCharts, 'Allocation Failed');
            const manifestFailed = transformRadial(data.data.issuesRadialCharts, 'Manifest Failed');

            this.setState({
                data: data.data,
                hasLoaded: true,
                preDespatchOverview: overview,
                allocatedCarriers: allocatedCarriers,
                allocatedCarrierServices: allocatedCarrierServices,
                unallocatedRadial: unallocatedRadial,
                allocationFailedRadial: allocationFailed,
                manifestFailedRadial: manifestFailed
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
                        <Tab>Not Shipped</Tab>
                        <Tab>Shipped</Tab>
                    </Tabs>
                    {this.state.activeTab === 0 ? (
                    <Grid>
                        <Cell col={4} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '280px', padding: '20px 20px 10px 20px'}}>
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className='mdl-card__title--center'>Unallocated</CardTitle>
                                <span className="radial-number">60</span>
                                <Doughnut data={this.state.unallocatedRadial} height={115} options={{cutoutPercentage: 80, legend: {display: false}, tooltips: {enabled: false}}} />
                                <CardActions style={{textAlign: 'center'}}>
                                    <Button raised className="mdl-button--dark-red">
                                        resolve
                                    </Button>
                                </CardActions>
                            </Card>
                        </Cell>
                        <Cell col={4} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '280px', padding: '20px 20px 10px 20px'}}>
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className='mdl-card__title--center'>Allocation Failed</CardTitle>
                                <span className="radial-number">60</span>
                                <Doughnut data={this.state.allocationFailedRadial} height={115} options={{cutoutPercentage: 80, legend: {display: false}, tooltips: {enabled: false}}} />
                                <CardActions style={{textAlign: 'center'}}>
                                    <Button raised className="mdl-button--dark-red">
                                        resolve
                                    </Button>
                                </CardActions>
                            </Card>
                        </Cell>
                        <Cell col={4} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '280px', padding: '20px 20px 10px 20px'}}>
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className='mdl-card__title--center'>Manifest Failed</CardTitle>
                                <span className="radial-number">0</span>
                                <Doughnut data={this.state.manifestFailedRadial} height={115} options={{cutoutPercentage: 80, legend: {display: false}, tooltips: {enabled: false}}} />
                                <CardActions style={{textAlign: 'center'}}>
                                    <Button raised disabled>
                                        resolve
                                    </Button>
                                </CardActions>
                            </Card>
                        </Cell>
                        <Cell col={6} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                              <Line data={this.state.preDespatchOverview} height={100} options={{maintainAspectRatio: false, legend: {display: false}}} />
                            </Card>
                        </Cell>
                            <Cell col={6} tablet={12} phone={12}>
                                <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                                            <HorizontalBar data={this.state.allocatedCarriers} options={{maintainAspectRatio: false, legend: {display: false}}} />
                                </Card>
                            </Cell>
                            <Cell col={12} phone={12}>
                                <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                    <HorizontalBar data={this.state.allocatedCarrierServices} height={100} options={{maintainAspectRatio: false, legend: {display: false}}} />
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
              borderWidth: 0.8,
              lineTension: 0.3,
              backgroundColor: Utils.colors.charts.blue_fade,
              borderColor: Utils.colors.charts.blue,
              borderCapStyle: 'butt',
              borderDash: [],
              borderDashOffset: 0.0,
              borderJoinStyle: 'miter',
              pointBorderColor: Utils.colors.charts.blue,
              pointBackgroundColor: '#fff',
              pointBorderWidth: 1,
              pointHoverRadius: 5,
              pointHoverBackgroundColor: Utils.colors.charts.blue,
              pointHoverBorderColor: Utils.colors.charts.blue,
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
                backgroundColor: Utils.colors.charts.blue_fade,
                borderColor: Utils.colors.charts.blue,
                borderWidth: 1,
                hoverBackgroundColor: Utils.colors.charts.blue,
                hoverBorderColor: Utils.colors.charts.blue,
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
                backgroundColor: Utils.colors.charts.blue_fade,
                borderColor: Utils.colors.charts.blue,
                borderWidth: 1,
                hoverBackgroundColor: Utils.colors.charts.blue,
                hoverBorderColor: Utils.colors.charts.blue,
                data: data
            }
        ]
    };

    return allocatedCarrierServicesBarData;

}
let transformRadial = (source, label) => {
    const radialSource = source.filter((r) => {
        return r.label === label;
    });
    var labels = [label, 'Others'];
    var data = [];
    data.push(radialSource[0].numerator);
    data.push(radialSource[0].denominator - radialSource[0].numerator);

    const hasData = data[0] > 0;

    const unallocatedRadial = {
        labels: labels,
        datasets:
        [
            {
                label: label,
                backgroundColor: hasData
                    ? [Utils.colors.charts.red, Utils.colors.charts.grey]
                    : [Utils.colors.charts.green, Utils.colors.charts.green ],
                borderColor: Utils.colors.charts.none,
                borderWidth: 1,
                hoverBackgroundColor: hasData
                    ? [Utils.colors.charts.red_dark, Utils.colors.charts.grey]
                    : [Utils.colors.charts.green, Utils.colors.charts.green],
                hoverBorderColor: hasData ? Utils.colors.charts.none : Utils.colors.charts.green,
                data: data

            }
        ],
        cutoutPercentage: 90
    };
    return unallocatedRadial;
}

export default DashboardContainer;