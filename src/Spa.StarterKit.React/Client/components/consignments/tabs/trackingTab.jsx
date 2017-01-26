import React, { Component } from 'react';
import { Card, CardTitle, CardText } from 'react-mdl';
import { DateTime } from '../../utils/dateFormatting';
import Table from 'react-toolbox/lib/table';

class TrackingTab extends Component {
    constructor(props) {
        super(props);
    }
    componentDidMount() {
        console.log("fetch tracking events here...");
    }
    render() {
        return(
             <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Tracking Events</CardTitle>
                <CardText className="tab--cardtext">
                    Nope
                </CardText>
            </Card>
        );
    }
}

export default TrackingTab;