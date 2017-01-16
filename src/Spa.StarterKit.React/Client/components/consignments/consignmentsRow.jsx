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
            selectable: this.props.type && this.props.type.substring(this.props.type.length, 3) !== "ing",
            selected: this.props.selected && this.state.selectable
        }

        this._selectRow = this._selectRow.bind(this);
    }
    _selectRow() {
        if (this.state.selectable) {
            this.setState({
                selected: !this.state.selected
            });            
        }
    }
    componentDidMount() {
        const consignmentState = this.props.consignmentState;
        const selectable = consignmentState && consignmentState.substring(consignmentState.length - 3) !== 'ing';
        this.setState({
            selectable: selectable,
            selected: this.props.selected && selectable
        });
    }
    render() {
        return(
            <tr className={(this.state.selectable && (this.state.selected || this.props.selected)) ? 'selected' : (!this.state.selectable ? 'locked' : null)} >
                <td><Checkbox disabled={!this.state.selectable} checked={this.state.selectable && (this.state.selected || this.props.selected)} onChange={() => this._selectRow()} /></td>
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