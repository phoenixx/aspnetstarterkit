import React from 'react';
import { Bar } from 'react-chartjs-2';
import { Button } from 'react-toolbox/lib/button';
import Utils from '../../utilities/utils';
import Loading from '../Loading';

class StackedChart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            chartData: null,
            reloading: false
        };
        this._transformChartData = this._transformChartData.bind(this);
        this._toggleLoading = this._toggleLoading.bind(this);
    }
    componentWillMount() {
        this.setState({
            chartData: this._transformChartData(
                this.props.sourceData,
                this.props.dataKey
                )
        });
    }
    _toggleLoading() {
        this.setState({
            reloading: !this.state.reloading
        });
    }
    _transformChartData(source, key) {

        const keys = [];

        for (const item of source) {
            const itemKeys = Object.keys(item);
            for (const itemKey of itemKeys) {
                if (keys.indexOf(itemKey) === -1 && itemKey !== key) {
                    keys.push(itemKey);
                }
            }
        }
        
        const dataKeys = [];
        const datasets = [];

        let i = 0;
        for (const dataKey of keys) {
            
            const values = [];

            for (const sourceData of source) {
                values.push(sourceData[dataKey] || 0);
            }
            
            datasets.push({
                label: dataKey,
                data: values,
                borderColor: Utils.colors.charts.foreground_colours[i],
                backgroundColor: Utils.colors.charts.foreground_colours[i],
                pointBorderColor: Utils.colors.charts.foreground_colours[i],
                pointBackgroundColor: Utils.colors.white,
                pointHoverBackgroundColor: Utils.colors.charts.foreground_colours[i],
                pointHoverBorderColor: Utils.colors.charts.foreground_colours[i],
                hoverBackgroundColor: Utils.colors.white,
                hoverBorderColor: Utils.colors.charts.foreground_colours[4],
                fill: true,
                borderWidth: 0.8
            });

            i += 1;
        }

        for (const sourceData of source) {
            dataKeys.push(sourceData[key]);
        }

        const chartData = {
            labels: dataKeys,
            datasets: datasets
        }

        return chartData;
    }
    render() {

        const defaultOptions = {
            maintainAspectRatio: false,
            legend: {
                display: false
            },
            scales: {
                yAxes: [
                     {
                         stacked: true,
                         ticks: {
                             beginAtZero: true
                         }
                     }]     
            }
        }

        return(
            <div className="chart-container">
                {(this.props.reloading || this.state.reloading) ? (
                    <div className="chart--loading">
                        <Loading />
                    </div>
                ) : (null)}
                <Bar data={this.state.chartData} height={100} options={{ maintainAspectRatio: false, legend: { display: true }, scales: { xAxes: [{ stacked: true, ticks: { beginAtZero: true } }], yAxes: [{stacked: true, ticks: {beginAtZero: true}}] } }} />
            </div>
            
        );
    }
}

export default StackedChart;