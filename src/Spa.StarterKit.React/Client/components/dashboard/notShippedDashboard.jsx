import React from 'react';
import {
    Button,
    Card,
    CardText,
    Grid,
    Cell } from 'react-mdl';
import SimpleChart from '../charts/SimpleChart';
import RadialChart from '../charts/RadialChart';
import MultiChart from '../charts/MultiChart';
import DatePicker from 'react-toolbox/lib/date_picker';

class NotShippedDashboard extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Grid>
                <Cell col={12} tablet={12} phone={12}>
                    <Card style={{width: '100%'}} className='chart-controls--card'>
                        <CardText>
                            <DatePicker label='Birthdate'/>
                        </CardText>
                    </Card>
                </Cell>
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
                    <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                        <SimpleChart label="State" sourceData={this.props.preDespatchOverviewData} chartType="Line" />
                    </Card>
                </Cell>
                <Cell col={6} tablet={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                        <SimpleChart label="Allocated Carrier" sourceData={this.props.allocatedCarriersData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px', padding: '20px'}}>
                        <SimpleChart label="Allocated Carrier Services" sourceData={this.props.allocatedCarrierServicesData} chartType="HorizontalBar" />
                    </Card>
                </Cell>
                <Cell col={12} phone={12}>
                    <Card shadow={0} style={{width: '100%' , height: '320px' , padding: '20px' }}>
                        <MultiChart Source={this.props.allocationByCarrierService} LabelPrefix="Week" NullLabelText="Not Allocated" />
                    </Card>
                </Cell>
            </Grid>
        );
    }
}

export default NotShippedDashboard;