import React, { Component } from 'react';
import {Tab, Tabs} from 'react-toolbox';
import PackagesTab from './tabs/packagesTab';
import { Card, CardTitle, CardText } from 'react-mdl';

class ConsignmentTabs extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Tabs index={this.props.activeTab} onChange={(tabId) => this.props.changeTab(tabId)} fixed>
                <Tab label="Packages" icon="card_giftcard">
                    <PackagesTab packages={this.props.packages} />
                </Tab>
                <Tab label="Documents" icon="description">
                    <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                        <CardTitle>Documents & labels</CardTitle>
                    </Card>
                </Tab>
                <Tab label="Tracking" icon="event">
                    <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                        <CardTitle>Tracking events</CardTitle>
                    </Card>
                </Tab>
                <Tab label="History" icon="history">
                    <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                        <CardTitle>History</CardTitle>
                    </Card>
                </Tab>
                <Tab label="Metadata" icon="hourglass_empty">
                    <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                        <CardTitle>Metadata</CardTitle>
                    </Card>
                </Tab>
            </Tabs>
        );
    }
}

export default ConsignmentTabs;