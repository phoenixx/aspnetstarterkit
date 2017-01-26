import React, { Component } from 'react';
import { Grid, Cell, Card, CardTitle, CardText } from 'react-mdl';
import { AddressDisplayContainer } from '../../containers/AddressContainer';
import PageHeader from '../layout/pageHeader';
import ConsignmentProperty from './consignmentProperty';
import { ShortDate, DateTime } from '../utils/dateFormatting';
import ConsignmentStatusHeader from './consignmentStatusHeader';
import AllocationDetails from './allocationDetails';
import PackagesTab from './tabs/packagesTab';
import EditAddressDialog from './editAddressDialog';
import { Button } from 'react-toolbox/lib/button';
import {Tab, Tabs} from 'react-toolbox';

import '../../sass/consignment.scss';

class ConsignmentView extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Grid>
                    <PageHeader title={`Consignment ${this.props.consignment.reference}`} />
                    <Cell col={3} tablet={12} phone={12}>
                        <Grid style={{margin: 0, padding: 0}}>
                            <Cell col={12} style={{margin:0, padding:0, width: '100%', marginBottom: '8px'}}>
                                <Card shadow={0} raised style={{height: '242px', width: '100%'}}>
                                <CardTitle>
                                    <h2>
                                        From
                                    </h2>
                                    <span style={{right:'16px', position: 'absolute'}}>
                                        <Button icon='create' label='Edit' primary onClick={() => this.props.toggleAddressDialog(this.props.origin)} />
                                    </span>
                                </CardTitle>
                                <CardText className="consignment-card">
                                    <AddressDisplayContainer address={this.props.origin} />
                                </CardText>
                                </Card>
                            </Cell>
                            <Cell col={12} style={{margin:0, padding:0, width: '100%', marginTop: '8px'}}>
                                <Card shadow={0} raised style={{height: '242px', width: '100%'}}>
                                <CardTitle>
                                    <h2>
                                        To
                                    </h2>
                                    <span style={{right:'16px', position: 'absolute'}}>
                                        <Button icon='create' label='Edit' primary onClick={() => this.props.toggleAddressDialog(this.props.destination)} />
                                    </span>
                                </CardTitle>
                                <CardText className="consignment-card">
                                    <AddressDisplayContainer address={this.props.destination} />
                                </CardText>
                                </Card>
                            </Cell>
                        </Grid>
                    </Cell>
                    <Cell col={3} tablet={12} phone={12}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>
                                <h2>
                                    Consignment details
                                </h2>
                                <span style={{right:'16px', position: 'absolute'}}>
                                    <Button icon='create' label='Edit' primary />
                                </span>
                            </CardTitle>
                            <CardText className="consignment-card">
                                <ConsignmentProperty label="Electio reference">
                                    {this.props.consignment.reference}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Your reference">
                                    {this.props.consignment.consignmentReferenceProvidedByCustomer}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Source">
                                    {this.props.consignment.source}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Shipping Terms">
                                    {this.props.consignment.shippingTerms}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Date created">
                                    <DateTime value={this.props.consignment.dateCreated} />
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Required delivery date">
                                    {this.props.consignment.requestedDeliveryDate
                                        ? (<ShortDate value={this.props.consignment.requestedDeliveryDate.date}/>)
                                        : (null)}
                                </ConsignmentProperty>
                                    {this.props.consignment.requestedDeliveryDate
                                        ? (
                                            <ConsignmentProperty label="Nominated day?">
                                                {this.props.consignment.requestedDeliveryDate.isToBeExactlyOnTheDateSpecified === true ? 'Yes' : 'No'}
                                            </ConsignmentProperty>
                                        )
                                        : (null)}
                                <ConsignmentProperty label="Shipping date">
                                    <ShortDate value={this.props.consignment.shippingDate} />
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Earliest delivery">
                                    <ShortDate value={this.props.consignment.earliestDeliveryDate} />
                                </ConsignmentProperty>
                            </CardText>
                        </Card>
                    </Cell>
                    <Cell col={6} tablet={12} phone={12}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>
                                <ConsignmentStatusHeader {...this.props.consignment} />
                            </CardTitle>
                            <CardText>
                                <AllocationDetails {...this.props.consignment} />
                            </CardText>
                        </Card>
                    </Cell>
                    <Cell col={12}>
                        <Tabs index={this.props.activeTab} onChange={(tabId) =>this.props.setActiveTab(tabId)} fixed>
                            <Tab label="Packages" icon="card_giftcard">
                                <PackagesTab packages={this.props.consignment.packages} />
                            </Tab>

                            <Tab label="Documents" icon="description">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Documents & labels</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="Tracking" icon="event">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Tracking events</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="History" icon="history">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>History</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="Metadata" icon="hourglass_empty">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Metadata</CardTitle>
                                </Card>
                            </Tab>
                        </Tabs>
                    </Cell>
                    <EditAddressDialog title='Edit address'
                                       active={this.props.showAddressDialog}
                                       toggleDialog={this.props.toggleAddressDialog}
                                       address={this.props.addressDialogData}
                                       countries={this.props.countries}
                                       consignmentReference={this.props.consignment.reference}
                                       shippingLocations={this.props.shippingLocations} />
                </Grid>
        );
    }
}

export default ConsignmentView;