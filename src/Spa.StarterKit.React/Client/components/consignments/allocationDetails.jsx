import React, { Component } from 'react';
import AllocationProperty from './allocationProperty';
import ConditionalComponent from '../utils/conditionalComponent';
import {Button} from 'react-toolbox/lib/button';
import { FormattedNumber } from 'react-intl'; //todo extract to utility component
import { ShortDate, DateTime } from '../utils/dateFormatting';

class AllocationDetails extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const inTransition = this.props.consignmentState.substring(this.props.consignmentState.length, 3) === "ing";

        const isAllocated = this.props.allocation !== null && this.props.consignmentState !== "Unallocated" && !inTransition;
        const allocFailed = !isAllocated && this.props.failedAllocation !== null;
        return(
            <div>
                <div className="panel">
                    <span className="panel--action">Available actions:</span>
                    <ConditionalComponent condition={() => isAllocated === false && inTransition === false}>
                        <Button icon='done' label='Allocate' raised primary className="button--action" />
                    </ConditionalComponent>
                    <ConditionalComponent condition={() => isAllocated === true}>
                        <Button icon='cancel' label='De-allocate' raised primary className="button--action" />
                        <Button icon='assignment' label='Manifest' raised primary className="button--action" />
                        <Button icon='print' label='Print labels' raised primary className="button--action" />
                    </ConditionalComponent>
                </div>
                {isAllocated === true
                    ? (
                        <div className="panel">
                            <span className="panel--title">Allocation details</span>
                            <AllocationProperty label="Service Name">{this.props.allocation.mpdCarrierServiceName}
                            </AllocationProperty>
                            <AllocationProperty label="Service Code">{this.props.allocation.mpdCarrierServiceReference}
                            </AllocationProperty>
                            <AllocationProperty label="Price">
                                <FormattedNumber value={this.props.allocation.price.net} style="currency" currency={this
                                .props.allocation.price.currency.isoCode}/>
                            </AllocationProperty>
                        </div>
                    )
                    : (null)}
                {allocFailed
                    ? (
                        <div className="panel">
                            <span className="panel--title">Allocation failure details</span>
                            <div className="allocation-failure-message">
                                <AllocationProperty label="Attempted allocation">
                                    <DateTime value={this.props.failedAllocation.attemptedAllocationDate}/>
                                </AllocationProperty>
                                <AllocationProperty label="Allocation failure reason">{this.props.failedAllocation.message}
                                </AllocationProperty>
                            </div>
                        </div>
                    )
                    : (null)}
                <span className="cancel-link">
                    <a href="#/">Cancel consignment</a>
                </span>
            </div>
        );
    }
}

export default AllocationDetails;