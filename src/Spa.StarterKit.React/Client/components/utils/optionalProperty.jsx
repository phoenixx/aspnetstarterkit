import React, { Component } from 'react';

class OptionalProperty extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <span className="property-group__item">
                {(this.props.children && this.props.children !== '' && this.props.children !== null)
                    ? (this.props.children)
                    : (
                        <span className="property-group__item--empty">
                            Not specified
                        </span>)
                 }
            </span>
        );
    }
}

export default OptionalProperty;