﻿import React from 'react';
import {
    Grid,
    Cell } from 'react-mdl';
import { Card, CardMedia, CardTitle, CardText, CardActions } from 'react-toolbox/lib/card';
import ChartControls from './chartControls';
import SimpleChart from '../charts/SimpleChart';
import RadialChart from '../charts/RadialChart';
import MultiChart from '../charts/MultiChart';
import MpdCardTitle from '../cards/cardTitle';

class NotShippedDashboard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            startDate: null,
            endDate: null
        }
    }
    render() {
        return(
            <Grid>
                <Cell col={12} tablet={12} phone={12}>
                    <ChartControls startDate={this.props.startDate} endDate={this.props.endDate} reload={this.props.reload}/>
                </Cell>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart source={this.props.radials} reloading={this.props.reloading} label="Unallocated" toggleLoadingState={this.props.toggleLoadingState} />
                </Cell>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart source={this.props.radials} reloading={this.props.reloading} label="Allocation Failed" />
                </Cell>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart source={this.props.radials} reloading={this.props.reloading} label="Manifest Failed" />
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Overview</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="State" sourceData={this.props.preDespatchOverviewData} chartType="Line" />
                    </Card>
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Carrier Allocation</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="Allocated Carrier" sourceData={this.props.allocatedCarriersData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Carrier Service Allocation</MpdCardTitle>
                        <SimpleChart reloading={this.props.reloading} label="Allocated Carrier Services" sourceData={this.props.allocatedCarrierServicesData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MpdCardTitle>Consignment Volume by Week</MpdCardTitle>
                        <MultiChart reloading={this.props.reloading} Source={this.props.allocationByCarrierService} LabelPrefix="Week" NullLabelText="Not Allocated" />
                    </Card>
                </Cell>
            </Grid>
        );
    }
}

export default NotShippedDashboard;