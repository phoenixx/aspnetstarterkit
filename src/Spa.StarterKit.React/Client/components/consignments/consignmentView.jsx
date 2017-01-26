import React, { Component } from 'react';
import { Grid, Cell, Card, CardTitle, CardText } from 'react-mdl';
import PageHeader from '../layout/pageHeader';
import ConsignmentStatusHeader from './consignmentStatusHeader';
import ConsignmentDetails from './consignmentDetails';
import AllocationDetails from './allocationDetails';
import EditAddressDialog from './editAddressDialog';
import { Button } from 'react-toolbox/lib/button';
import {Tab, Tabs} from 'react-toolbox';
import AddressPanel from './addressPanel';
import ConsignmentTabs from './consignmentTabs';

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
                        <AddressPanel address={this.props.origin} toggleAddressDialog={this.props.toggleAddressDialog} title="From:"/>
                        <AddressPanel address={this.props.destination} toggleAddressDialog={this.props.toggleAddressDialog} title="To:" />
                    </Grid>
                </Cell>
                <Cell col={3} tablet={12} phone={12}>
                    <ConsignmentDetails {...this.props.consignment}/>
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
                    <ConsignmentTabs activeTab={this.props.activeTab} changeTab={this.props.setActiveTab} consignment={this.props.consignment}/>
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