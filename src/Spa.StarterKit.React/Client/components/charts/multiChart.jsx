import React from 'react';
import {Doughnut, HorizontalBar, Line, Polar, Bar, Pie} from 'react-chartjs-2';
import Utils from '../../utilities/utils';

class MultiChart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            chartData: null
        };
        this._transformChartData = this._transformChartData.bind(this);
    }
    componentWillMount() {
        this.setState({
            chartData: this._transformChartData(
                this.props.Source,
                this.props.LabelPrefix,
                this.props.NullLabelText)
        });
    }
    _transformChartData(source, labelPrefix, nullLabelText) {
        const chartData = {
            labels: source.labels.map((lbl) => {
                return `${labelPrefix} ${lbl}`;
            }),
            datasets: []
        };

        let i = 0;
        source.datasets.map((ds) => {
            chartData.datasets.push({
                label: ds.label == null ? nullLabelText : ds.label,
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

        return chartData;
    }
    render() {
        return(
            <div className="chart-container">
                <Line data={this.state.chartData} height={100} options={{maintainAspectRatio: false, legend: {display: true}}} />
            </div>
            
        );
    }
}

export default MultiChart;