import React from 'react';
//import { Tabs, Tab } from 'react-mdl';
import { Tab, Tabs } from 'react-toolbox';
import Loading from '../components/Loading';
import NotShippedDashboard from '../components/dashboard/notShippedDashboard';
import ShippedDashboard from '../components/dashboard/shippedDashboard';
import '../sass/dashboard.scss';

class Dashboard extends React.Component {
    render() {
        return (
           this.props.hasLoaded === false ? (
                <Loading />
            )
            :
            (
                <div>
                    <Tabs index={this.props.activeTab} onChange={(tabId) => this.props.setActiveTab(tabId)} fixed>
                        <Tab label="Not Shipped" icon="assignment">
                            <NotShippedDashboard {...this.props} />
                        </Tab>
                        <Tab label="Shipped" icon="assignment_turned_in">
                            <ShippedDashboard {...this.props} />
                        </Tab>
                    </Tabs>
            </div>
            ) 
        );
    }    
}

export default Dashboard;