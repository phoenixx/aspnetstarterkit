import React, { Component } from 'react';
import {Tab, Tabs} from 'react-toolbox';
import PackagesTab from './tabs/packagesTab';
import DocumentsTab from './tabs/documentsTab';
import TrackingTab from './tabs/trackingTab';
import HistoryTab from './tabs/historyTab';
import MetadataTab from './tabs/metadataTab';

class ConsignmentTabs extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Tabs index={this.props.activeTab} onChange={(tabId) => this.props.changeTab(tabId)} fixed>
                <Tab label="Packages" icon="card_giftcard">
                    <PackagesTab packages={this.props.consignment.packages} />
                </Tab>
                <Tab label="Documents" icon="description">
                    <DocumentsTab consignment={this.props.consignment} />
                </Tab>
                <Tab label="Tracking" icon="event">
                   <TrackingTab consignmentReference={this.props.consignment.reference}/>
                </Tab>
                <Tab label="History" icon="history">
                   <HistoryTab consignmentReference={this.props.consignment.reference} />
                </Tab>
                <Tab label="Metadata" icon="hourglass_empty">
                    <MetadataTab consignmentReference={this.props.consignment.reference}/>
                </Tab>
            </Tabs>
        );
    }
}

export default ConsignmentTabs;