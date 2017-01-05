import React from 'react';
import {
    Grid,
    Cell } from 'react-mdl';
import { Card, CardMedia, CardTitle, CardText, CardActions } from 'react-toolbox/lib/card';
import SimpleChart from '../charts/SimpleChart';
import RadialChart from '../charts/RadialChart';
import MultiChart from '../charts/MultiChart';

class NotShippedDashboard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            startDate: null,
            endDate: null
        }
    }
    _handleChange(item, value) {
        console.log('set ' + item + ' to ' + value);
        this.setState({
            [item]: value
        });
    }
    render() {
        return(
            <Grid>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart Source={this.props.radials} Label="Unallocated" />
                </Cell>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart Source={this.props.radials} Label="Allocation Failed" />
                </Cell>
                <Cell col={4} tablet={12} phone={12}>
                    <RadialChart Source={this.props.radials} Label="Manifest Failed" />
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <SimpleChart label="State" sourceData={this.props.preDespatchOverviewData} chartType="Line" />
                    </Card>
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <SimpleChart label="Allocated Carrier" sourceData={this.props.allocatedCarriersData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <SimpleChart label="Allocated Carrier Services" sourceData={this.props.allocatedCarrierServicesData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px'}} raised>
                        <MultiChart Source={this.props.allocationByCarrierService} LabelPrefix="Week" NullLabelText="Not Allocated" />
                    </Card>
                </Cell>
            </Grid>
        );
    }
}

export default NotShippedDashboard;