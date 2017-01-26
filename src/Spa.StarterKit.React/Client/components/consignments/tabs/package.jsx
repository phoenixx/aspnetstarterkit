import React, { Component } from 'react';
import {Button, IconButton} from 'react-toolbox/lib/button';
import OptionalProperty from '../../utils/optionalProperty';
import { FormattedNumber } from 'react-intl'; 

class Package extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="package-container">
                <div className="package-reference">
                    Package {this.props.reference}
                </div>
                <div className="package-edit">
                        <Button icon='create' label='Edit' primary />
                </div>
                <table className="package-table">
                    <thead>
                        <tr>
                            <th>Your reference</th>
                            <th>Description</th>
                            <th>Dimensions</th>
                            <th>Value</th>
                            <th>Barcode</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <OptionalProperty>{this.props.packageReferenceProvidedByCustomer}
                                </OptionalProperty>
                            </td>
                            <td>{this.props.description}</td>
                            <td>{this.props.dimensions.height}cm x {this.props.dimensions.length}cm x {this.props
                                .dimensions.width}cm</td>
                            <td><FormattedNumber value={this.props.value.amount} style="currency" currency={this.props.value.currency.isoCode} /></td>
                            <td>
                                <OptionalProperty>{this.props.barcode}
                                </OptionalProperty>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }
}

export default Package;