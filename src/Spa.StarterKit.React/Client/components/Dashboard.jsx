import React from 'react';
import { Tabs, Tab } from 'react-mdl';
import Loading from '../components/Loading';
import NotShippedDashboard from '../components/dashboard/notShippedDashboard';
import ShippedDashboard from '../components/dashboard/shippedDashboard';
//import '../sass/dashboard.scss';

class Dashboard extends React.Component {
    render() {
        return (
           this.props.hasLoaded === false ? (
                <Loading />
            )
            :
            (
                <div>
                    <Tabs activeTab={this.props.activeTab} onChange={(tabId) => this.props.setActiveTab(tabId)} ripple>
                        <Tab>Not Shipped</Tab>
                        <Tab>Shipped</Tab>
                    </Tabs>
                    {this.props.activeTab === 0 ? (
                        <NotShippedDashboard {...this.props}/>
                    ) : (
                        <ShippedDashboard {...this.props}/>
                    )}
            </div>
            ) 
        );
    }    
}

export default Dashboard;