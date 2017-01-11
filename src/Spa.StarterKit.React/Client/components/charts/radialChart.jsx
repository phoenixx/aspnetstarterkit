import React from 'react';
import {Doughnut} from 'react-chartjs-2';
//import { Card, CardTitle, CardActions } from 'react-mdl';
import { Card, CardMedia, CardTitle, CardText, CardActions } from 'react-toolbox/lib/card';
import Utils from '../../utilities/utils';
import { Button } from 'react-toolbox/lib/button';
import RedButton from '../buttons/redbutton';
import MpdCardTitle from '../cards/cardTitle';
import Loading from '../Loading';
import cardActionsTheme from '../cards/cardActions.scss';

class RadialChart extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            chartData: null,
            count: 0,
            reloading: false //used for self-trigger of reload...
        };
        this._transformRadial = this._transformRadial.bind(this);
        this._getNumerator = this._getNumerator.bind(this);
    }
    componentWillMount() {
        this.setState({
            chartData: this._transformRadial(this.props.source, this.props.label),
            count: this._getNumerator(this.props.source, this.props.label)
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
            <Card shadow={0} style={{width: '100%' , height: '320px', padding: '0'}} raised>

                <MpdCardTitle>
                    {this.props.label}
                </MpdCardTitle>
                <div className="radial-container" style={{height: '80%', position: 'relative'}}>
                    {(this.props.reloading || this.state.reloading) ? (
                    <div className="radial--loading">
                        <Loading />
                    </div>
                    ) : (
                        <span className="radial-number">{this.state.count}</span>
                    )}
                    
                    {(!this.props.reloading && !this.state.reloading) ? (
                        <Doughnut data={this.state.chartData} options={{maintainAspectRatio: false, cutoutPercentage: 80, legend: {display: false}, tooltips: {enabled: false}}} />
                    ): (null)}
                    
                </div>
                {(!this.props.reloading && !this.state.reloading) ? (
                    <CardActions style={{textAlign: 'center'}} theme={cardActionsTheme}>
                        <RedButton raised disabled={this.state.count === 0}>
                            resolve
                        </RedButton>
                    </CardActions>
                ) : (null)}

            </Card>
        );
    }
}

export default RadialChart;