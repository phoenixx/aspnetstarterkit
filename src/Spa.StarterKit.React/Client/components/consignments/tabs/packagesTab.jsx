import React, { Component } from 'react';
import Package from './package';
import { Card, CardTitle, CardText } from 'react-mdl';

class PackagesTab extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Packages</CardTitle>
                <CardText className="tab--cardtext">
                    {this.props.packages.map((pkg) => {
                        return (<Package {...pkg}/>);
                    })}
                </CardText>
             </Card>
        );
    }
}

export default PackagesTab;