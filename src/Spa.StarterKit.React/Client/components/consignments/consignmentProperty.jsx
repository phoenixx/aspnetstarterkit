import React, { Component } from 'react';
import OptionalProperty from '../utils/optionalProperty';

class ConsignmentProperty extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="property-group">
                <span className="property-group__label">
                    {this.props.label}:
                </span>
                <OptionalProperty>
                    {this.props.children}
                </OptionalProperty>
            </div>
        );
    }
}

export default ConsignmentProperty;