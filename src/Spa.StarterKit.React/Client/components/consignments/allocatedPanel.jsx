import React, { Component } from 'react';
import AllocationProperty from './allocationProperty';
import { FormattedNumber } from 'react-intl'; 
import {Button, IconButton} from 'react-toolbox/lib/button';

class AllocatedPanel extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div>
                <div className="panel">
                    <span className="panel--action">Available actions:</span>
                    <Button icon='cancel' label='De-allocate' raised primary className="button--action" />
                    <Button icon='assignment' label='Manifest' raised primary className="button--action" />
                    <Button icon='print' label='Print labels' raised primary className="button--action" />
                </div>
                <div className="panel">
                    <span className="panel--title">Allocation details</span>
                    <AllocationProperty label="Service Name">{this.props.mpdCarrierServiceName}
                    </AllocationProperty>
                    <AllocationProperty label="Service Code">{this.props.mpdCarrierServiceReference}
                    </AllocationProperty>
                    <AllocationProperty label="Price">
                        <FormattedNumber value={this.props.price.net} style="currency" currency={this.props.price.currency.isoCode} />
                    </AllocationProperty>
                </div>
                <span className="cancel-link">
                    <a href="#/">Cancel consignment</a>
                </span>
            </div>

        );
    }
}

export default AllocatedPanel;