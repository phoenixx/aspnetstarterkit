import React from 'react';
import {Doughnut, HorizontalBar, Line, Polar, Bar, Pie} from 'react-chartjs-2';
import Utils from '../../utilities/utils';

class SimpleChart extends React.Component {
    constructor(props) {
        super(props);
        this._transformChartData = this._transformChartData.bind(this);
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
              }]
        }

        return chartSourceData;
    }
    render() {
        const chartType = this.props.chartType;
        switch (chartType) {
        case 'Line':
            return(
                <Line
                    data={this._transformChartData(this.props.sourceData, this.props.label)}
                    height={100}
                    options={{ maintainAspectRatio: false, legend: { display: false } }}/>
            );
        case 'HorizontalBar':
            return(
                <HorizontalBar
                    data={this._transformChartData(this.props.sourceData, this.props.label)}
                    height={100} 
                    options={{maintainAspectRatio: false, legend: { display: false }}}/>
            );
        default:
            return(
                <div>Invalid chart type '{this.props.chartType}'</div>
            );
        }
    }
}

export default SimpleChart;