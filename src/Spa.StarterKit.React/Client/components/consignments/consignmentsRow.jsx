import React, { Component } from 'react'
import Checkbox from '../checkbox/checkbox';
import FontIcon from 'react-toolbox/lib/font_icon';
import { ShortDate, DateTime } from '../utils/dateFormatting';
import { FormattedNumber } from 'react-intl'; //todo extract to utility component
import { Link } from 'react-router';

class ConsignmentsRow extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: this.props.selected //initial
        }

        this._selectRow = this._selectRow.bind(this);
    }
    _selectRow() {
        this.setState({
            selected: !this.state.selected
        });
    }
    render() {
        return(
            <tr className={(this.state.selected || this.props.selected) ? 'selected' : null} >
                <td><Checkbox checked={this.state.selected || this.props.selected} onChange={() => this._selectRow()} /></td>
                <td>
                    <Link to={`/consignment/${this.props.consignmentReference}`} rel="consignment" >
                        {this.props.consignmentReference}
                    </Link>
                </td>
                <td>{this.props.clientReference}</td>
                <td className="center"><DateTime value={this.props.created} /></td>
                <td className="center"><FormattedNumber value={this.props.weight} /></td>
                <td className="center"><FormattedNumber value={this.props.value.amount} style="currency" currency={this.props.value.currency.isoCode} /></td>
                <td className="center"><ShortDate value={this.props.shippingDate} /></td>
                <td className="center">
                    {this.props.requestedDeliveryDate !== null
                        ? (<ShortDate value={this.props.requestedDeliveryDate.date}/>)
                        : (null)}
                </td>
                <td><ShortDate value={this.props.earliestDeliveryDate} /></td>
                <td>{this.props.consignmentState}</td>
                <td>{this.props.destinationAddress}</td>
                <td className="center">{this.props.haveLabelsEverBeenPrinted
                    ? (<FontIcon value='done'/>)
                    : (<FontIcon value='clear'/>)}</td>
            </tr>
        );
    }
}

export default ConsignmentsRow;