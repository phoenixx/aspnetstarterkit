import React from 'react';
import {Doughnut, HorizontalBar, Line, Polar, Bar, Pie} from 'react-chartjs-2';
import Utils from '../../utilities/utils';
import Loading from '../Loading';

class SimpleChart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            reloading: false,
            chartType: this.props.chartType
        }
        this._transformChartData = this._transformChartData.bind(this);
        this._getChartType = this._getChartType.bind(this);
        this._toggleLoading = this._toggleLoading.bind(this);
    }
    _toggleLoading() {
        console.log("clicked");
        this.setState({
            reloading: true
        });
    }
    _transformChartData(source, label) {
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
                    label: label,
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
                }
            ]
        }

        return chartSourceData;
    }

    _getChartType(chartType) {

        const defaultOptions = {
            maintainAspectRatio: false,
            legend: {
                 display: false
            }
        };
        const axisDefaults = {
            scales: {
                yAxes: [
                     {
                         ticks: {
                             beginAtZero: true
                         }
                     }]     
            }
        }

        const defaultOptionsWithAxis = Object.assign({}, defaultOptions, axisDefaults);
        
        switch (chartType) {
            case 'Line':
                return (
                    <Line data={this._transformChartData(this.props.sourceData, this.props.label)} height={100} options={defaultOptionsWithAxis} />
                );
            case 'HorizontalBar':
                return(
                    <HorizontalBar data={this._transformChartData(this.props.sourceData, this.props.label)} height={100} options={defaultOptionsWithAxis} />
                );
            case 'Bar':
                return (
                    <Bar data={this._transformChartData(this.props.sourceData, this.props.label)} height={100} options={defaultOptionsWithAxis} />
                );
            case 'Doughnut':
                return(
                    <Doughnut data={this._transformChartData(this.props.sourceData, this.props.label)} height={100} options={defaultOptions} />
                );
            default:
                return(
                    <span>
                        Invalid chart type '{chartType}'
                    </span>

                );
        }
    }

    render() {
        let chartRender = this._getChartType(this.state.chartType);

        return (
            <div className="chart-container">
                {(this.props.reloading || this.state.reloading)
                ?
                (
                        <div className="chart--loading">
                            <Loading />
                        </div>
                )
                : (null)}
                <div className="chart-container--inner">
                    {chartRender}
                </div>
            </div>
        );
    }
}

export default SimpleChart;