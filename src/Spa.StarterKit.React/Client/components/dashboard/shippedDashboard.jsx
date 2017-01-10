import React, { Component } from 'react';
import {
    Button,
    Card,
    Grid,
    Cell } from 'react-mdl';
import ChartControls from './chartControls';
import SimpleChart from '../charts/SimpleChart';
import RadialChart from '../charts/RadialChart';
import StackedChart from '../charts/StackedChart';
import MpdCardTitle from '../cards/cardTitle';

class ShippedDashboard extends Component {
    render() {
        return(
            <Grid>
                <Cell col={12} tablet={12} phone={12}>
                    <ChartControls startDate={this.props.startDate} endDate={this.props.endDate} reload={this.props.reload} />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Action Required" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Missing" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Lost" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Damaged" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Delivery Failed" />
                </Cell>
                <Cell col={2} tablet={12} phone={12}>
                    <RadialChart reloading={this.props.reloading} source={this.props.shippedRadials} label="Partially Delivered" />
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                         <MpdCardTitle>Issues by Carrier</MpdCardTitle>
                         <StackedChart reloading={this.props.reloading} label="Issues" sourceData={this.props.issuesByCarrier} dataKey="carrier" />
                    </Card>
                </Cell>
                 <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Late Summary</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="Late" sourceData={this.props.lateConsignmentsPie} chartType="Doughnut" />
                    </Card>
                 </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Late by Days</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="Late" sourceData={this.props.lateConsignmentsBar} chartType="Bar" />
                    </Card>
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Late by Carrier</MpdCardTitle>
                        <StackedChart reloading={this.props.reloading} label="Late" sourceData={this.props.lateConsignmentsByCarrier} dataKey="Carrier" />
                    </Card>
                </Cell>
                <Cell col={12} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Shipped Overview</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="Consignments" sourceData={this.props.shippedOverview} chartType="Bar" />
                    </Card>
                </Cell>
            </Grid>
        );
    }
}

export default ShippedDashboard;