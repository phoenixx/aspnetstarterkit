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
import SimpleChart from '../components/charts/SimpleChart';

class DashboardContainer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeTab: 0,
            hasLoaded: false,
            globalStart: null,
            globalEnd: null,
            //data: null,
            //preDespatchOverview: null,
            //allocatedCarriers: null,
            //allocatedCarrierServices: null,
            unallocatedRadial: null,
            allocationFailedRadial: null,
            manifestFailedRadial: null,
            allocationByCarrierService: null,
            preDespatchOverviewData: null,
            allocatedCarriersData: null,
            allocatedCarrierServicesData: null
        }
    }
    componentDidMount() {
        getDashboardData().then((data) => {
            //const overview = transformChartData(data.data.preDespatchOverviewBarChart);// transformPreDespatchOverview(data.data);
            //const allocatedCarriers = transformChartData(data.data.allocatedCarriersBarChart, 'Allocated Carriers');// transformAllocatedCarriers(data.data);
            //const allocatedCarrierServices = transformChartData(data.data.allocatedCarrierServicesBarChart, 'Allocated Carrier Services');// transformAllocatedCarrierServices(data.data);
            const unallocatedRadial = transformRadial(data.data.issuesRadialCharts, 'Unallocated');
            const allocationFailed = transformRadial(data.data.issuesRadialCharts, 'Allocation Failed');
            const manifestFailed = transformRadial(data.data.issuesRadialCharts, 'Manifest Failed');
            const allocationByCarrierService = allocationByCarrierServiceByDate(data.data);

            this.setState({
                //data: data.data,
                hasLoaded: true,
                //preDespatchOverview: overview,
                //allocatedCarriers: allocatedCarriers,
                //allocatedCarrierServices: allocatedCarrierServices,
                unallocatedRadial: unallocatedRadial,
                allocationFailedRadial: allocationFailed,
                manifestFailedRadial: manifestFailed,
                allocationByCarrierService: allocationByCarrierService,
                preDespatchOverviewData: data.data.preDespatchOverviewBarChart,
                allocatedCarriersData: data.data.allocatedCarriersBarChart,
                allocatedCarrierServicesData: data.data.allocatedCarrierServicesBarChart
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
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className="mdl-card__title--center">Unallocated</CardTitle>
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
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className="mdl-card__title--center">Allocation Failed</CardTitle>
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
                                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className="mdl-card__title--center">Manifest Failed</CardTitle>
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
                                <SimpleChart
                                    label="State" 
                                    sourceData={this.state.preDespatchOverviewData}
                                    chartType="Line"/>
                            </Card>
                        </Cell>
                        <Cell col={6} tablet={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                <SimpleChart
                                    label="Allocated Carrier" 
                                    sourceData={this.state.allocatedCarriersData}
                                    chartType="HorizontalBar"/>
                            </Card>
                        </Cell>
                        <Cell col={12} phone={12}>
                            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                                <SimpleChart label="Allocated Carrier Services"
                                    sourceData={this.state.allocatedCarrierServicesData}
                                    chartType="HorizontalBar" />
                            </Card>
                        </Cell>
                        <Cell col={12} phone={12}>
                           <Card shadow={0} style={{width: '100%' , height: '320px' , padding: '20px' }}>
                               <Line data={this.state.allocationByCarrierService} height={100} options={{maintainAspectRatio: false, legend: {display: true}}} />
                            </Card>
                        </Cell>
                    </Grid>
                    ) : (
                        <div>post despatch</div>
                    )}

                </div>
            )
        );
    }
}

const getDashboardData = () => {
    return axios.get('/dashboard/predespatch/')
    .then(function(dashboardResponse) {
        //console.log(dashboardResponse);
        return dashboardResponse;
    });
}
//extract radial
//extract mixed chart
//allow type selector
//allow filtering of dates
//separate logic and view into separate components (smart/sumb)

//const transformChartData = (source, label) => {
//    const labels = source.map(item => {
//        return item.name;
//    });
//    const datapoints = source.map(item => {
//        return item.value;
//    });
//    const chartSourceData = {
//        labels: labels,
//        datasets: [
//          {
//              label: 'Status',
//              fill: true,
//              borderWidth: 0.8,
//              lineTension: 0.3,
//              backgroundColor: Utils.colors.charts.blue_fade,
//              borderColor: Utils.colors.charts.blue,
//              borderCapStyle: 'butt',
//              borderDash: [],
//              borderDashOffset: 0.0,
//              borderJoinStyle: 'miter',
//              pointBorderColor: Utils.colors.charts.blue,
//              pointBackgroundColor: '#fff',
//              pointBorderWidth: 1,
//              pointHoverRadius: 5,
//              pointHoverBackgroundColor: Utils.colors.charts.blue,
//              pointHoverBorderColor: Utils.colors.charts.blue,
//              pointHoverBorderWidth: 2,
//              pointRadius: 6,
//              pointHitRadius: 40,
//              data: datapoints,
//              legend: false
//          }]
//    }

//    return chartSourceData;
//}

//TODO abstract into reusable utility funtions
//const transformPreDespatchOverview = (inputData) => {
//    const source = inputData.preDespatchOverviewBarChart;
//    const labels = source.map(item => {
//        return item.name;
//    });
//    const datapoints = source.map(item => {
//        return item.value;
//    });
//    const chartSourceData = {
//        labels: labels,
//        datasets: [
//          {
//              label: 'Status',
//              fill: true,
//              borderWidth: 0.8,
//              lineTension: 0.3,
//              backgroundColor: Utils.colors.charts.blue_fade,
//              borderColor: Utils.colors.charts.blue,
//              borderCapStyle: 'butt',
//              borderDash: [],
//              borderDashOffset: 0.0,
//              borderJoinStyle: 'miter',
//              pointBorderColor: Utils.colors.charts.blue,
//              pointBackgroundColor: '#fff',
//              pointBorderWidth: 1,
//              pointHoverRadius: 5,
//              pointHoverBackgroundColor: Utils.colors.charts.blue,
//              pointHoverBorderColor: Utils.colors.charts.blue,
//              pointHoverBorderWidth: 2,
//              pointRadius: 6,
//              pointHitRadius: 40,
//              data: datapoints,
//              legend: false
//          }]
//    }

//    return chartSourceData;
//}

//const transformAllocatedCarriers = (inputData) => {
//    const source = inputData.allocatedCarriersBarChart;
//    const labels = source.map(item => {
//        return item.name;
//    });
//    const data = source.map(item => {
//        return item.value;
//    });

//    const allocatedCarriersBarData = {
//        labels: labels,
//        datasets:
//        [
//            {
//                label: 'Allocated Carriers',
//                backgroundColor: Utils.colors.charts.blue_fade,
//                borderColor: Utils.colors.charts.blue,
//                borderWidth: 1,
//                hoverBackgroundColor: Utils.colors.charts.blue,
//                hoverBorderColor: Utils.colors.charts.blue,
//                data: data
//            }
//        ]
//    };

//    return allocatedCarriersBarData;

//}

//const transformAllocatedCarrierServices = (inputData) => {
//    const source = inputData.allocatedCarrierServicesBarChart;
//    const labels = source.map(item => {
//        return item.name;
//    });
//    const data = source.map(item => {
//        return item.value;
//    });

//    const allocatedCarrierServicesBarData = {
//        labels: labels,
//        datasets:
//        [
//            {
//                label: 'Allocated Carrier Services',
//                backgroundColor: Utils.colors.charts.blue_fade,
//                borderColor: Utils.colors.charts.blue,
//                borderWidth: 1,
//                hoverBackgroundColor: Utils.colors.charts.blue,
//                hoverBorderColor: Utils.colors.charts.blue,
//                data: data
//            }
//        ]
//    };

//    return allocatedCarrierServicesBarData;

//}

const transformRadial = (source, label) => {
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

const allocationByCarrierServiceByDate = (input) => {
    const source = input.allocationByCarrierService;

    const allocationChartData = {
        labels: source.labels.map((lbl) => {
            return `Week ${lbl}`;
        }),
        datasets: []
    };

    let i = 0;
    source.datasets.map((ds) => {
       allocationChartData.datasets.push({
            label: ds.label == null ? 'Not allocated' : ds.label,
            data: ds.values,
            borderColor: Utils.colors.charts.foreground_colours[i],
            backgroundColor: Utils.colors.charts.background_colours[i],
            pointBorderColor: Utils.colors.charts.background_colours[i],
            pointBackgroundColor: Utils.colors.white,
            pointHoverBackgroundColor: Utils.colors.charts.foreground_colours[i],
            pointHoverBorderColor: Utils.colors.charts.foreground_colours[i],
            hoverBackgroundColor: Utils.colors.white,
            hoverBorderColor: Utils.colors.red,
            fill: true
       });
        i += 1;
    });

    return allocationChartData;
}

export default DashboardContainer;