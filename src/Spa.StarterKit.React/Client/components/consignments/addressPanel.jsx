import React, { Component } from 'react';
import { Cell, Card, CardTitle, CardText } from 'react-mdl';
import { Button } from 'react-toolbox/lib/button';
import AddressDisplay from '../common/addressDisplay';

class AddressPanel extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
             <Cell col={12} style={{margin:0, padding:0, width: '100%', marginBottom: '16px'}}>
                <Card shadow={0} raised style={{height: '242px', width: '100%'}}>
                <CardTitle>
                    <h2>
                        {this.props.title}
                    </h2>
                    <span style={{right:'16px', position: 'absolute'}}>
                        <Button icon='create' label='Edit' primary onClick={() => this.props.toggleAddressDialog(this.props.address)} />
                    </span>
                </CardTitle>
                <CardText className="consignment-card">
                    <AddressDisplay address={this.props.address} />
                </CardText>
                </Card>
            </Cell>
        );
    }
}

export default AddressPanel;