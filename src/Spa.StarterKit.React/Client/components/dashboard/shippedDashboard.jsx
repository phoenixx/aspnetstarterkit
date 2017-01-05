import React, { Component } from 'react';
import {
    Button,
    Card,
    Grid,
    Cell } from 'react-mdl';
import ChartControls from './chartControls';
import SimpleChart from '../charts/SimpleChart';
import RadialChart from '../charts/RadialChart';
import MultiChart from '../charts/MultiChart';


class ShippedDashboard extends Component {
    render() {
        return(
            <Grid>
                <Cell col={12} tablet={12} phone={12}>
                    <ChartControls startDate={this.props.startDate} endDate={this.props.endDate} reload={this.props.reload} />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Action Required" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Missing" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Lost" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Damaged" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Delivery Failed" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart Source={this.props.shippedRadials} Label="Partially Delivered" />
                </Cell>

            </Grid>
        );
    }
}

export default ShippedDashboard;