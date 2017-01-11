import React, { Component } from 'react';

class ConsignmentContainer extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(<div>i am consignment {this.props.params.consignmentReference}</div>);
    }
}

export default ConsignmentContainer;