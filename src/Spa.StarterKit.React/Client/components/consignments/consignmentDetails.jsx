import React, { Component } from 'react';
import { Card, CardTitle, CardText } from 'react-mdl';
import ConsignmentProperty from './consignmentProperty';
import { ShortDate, DateTime } from '../utils/dateFormatting';
import { Button } from 'react-toolbox/lib/button';


class ConsignmentDetails extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
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
                        {this.props.reference}
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Your reference">
                        {this.props.consignmentReferenceProvidedByCustomer}
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Source">
                        {this.props.source}
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Shipping Terms">
                        {this.props.shippingTerms}
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Date created">
                        <DateTime value={this.props.dateCreated} />
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Required delivery date">
                        {this.props.requestedDeliveryDate
                            ? (<ShortDate value={this.props.requestedDeliveryDate.date}/>)
                            : (null)}
                    </ConsignmentProperty>
                    {this.props.requestedDeliveryDate
                        ?
                        (
                            <ConsignmentProperty label="Nominated day?">
                                {this.props.requestedDeliveryDate.isToBeExactlyOnTheDateSpecified === true ? 'Yes' : 'No'}
                            </ConsignmentProperty>
                        )
                        : (null)}
                    <ConsignmentProperty label="Shipping date">
                        <ShortDate value={this.props.shippingDate} />
                    </ConsignmentProperty>
                    <ConsignmentProperty label="Earliest delivery">
                        <ShortDate value={this.props.earliestDeliveryDate} />
                    </ConsignmentProperty>
                </CardText>
            </Card>
        );
    }
}

export default ConsignmentDetails;