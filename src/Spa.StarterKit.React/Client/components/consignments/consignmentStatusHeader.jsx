import React, { Component } from 'react';
import Utils from '../utils/utils';
import FontIcon from 'react-toolbox/lib/font_icon';
import '../../sass/consignment.scss';

class ConsignmentStatusHeader extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const consignmentState = `Consignment status: ${Utils.splitCamelCase(this.props.consignmentState)}`;
        return(
            <h2>
                {consignmentState}
                {this.props.isLate
                    ? (
                        <span className="late-icon">
                            <FontIcon value='alarm'/> Late
                        </span>
                    )
                    : (null)}
            </h2>
        );
    }
}

export default ConsignmentStatusHeader;