﻿import React from 'react';
import {Doughnut} from 'react-chartjs-2';
import { Button, Card, CardTitle, CardActions } from 'react-mdl';
import Utils from '../../utilities/utils';

class RadialChart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            chartData: null,
            count: 0
        };
        this._transformRadial = this._transformRadial.bind(this);
        this._getNumerator = this._getNumerator.bind(this);
    }
    componentWillMount() {
        this.setState({
            chartData: this._transformRadial(this.props.Source, this.props.Label),
            count: this._getNumerator(this.props.Source, this.props.Label)
        });
    }
    _getNumerator(source, label) {
        const radialSource = source.filter((r) => {
            return r.label === label;
        });

        return radialSource[0].numerator;
    }
    _transformRadial(source, label) {
        const radialSource = source.filter((r) => {
            return r.label === label;
        });
        const labels = [label, 'Others'];
        const data = [];
        
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
    render() {
        return(
            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px 20px 100px 20px'}}>
                <CardTitle style={{color: Utils.colors.black, height: '40px', textAlign: 'center'}} className="mdl-card__title--center">
                    {this.props.Label}
                </CardTitle>
                <span className="radial-number">{this.state.count}</span>
                <Doughnut data={this.state.chartData} height={20} options={{maintainAspectRatio: false, cutoutPercentage: 80, legend: {display: false}, tooltips: {enabled: false}}} />
                <CardActions style={{textAlign: 'center'}}>
                    <Button raised className="mdl-button--dark-red" disabled={this.state.count === 0}>
                        resolve
                    </Button>
                </CardActions>
            </Card>
        );
    }
}

export default RadialChart;