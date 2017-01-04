import React, { PropTypes } from 'react';
import { browserHistory } from 'react-router'
import { IconMenu, MenuItem, MenuDivider} from 'react-toolbox/lib/menu';
import { List, ListItem, ListDivider, ListSubHeader } from 'react-toolbox';


class SideDrawer extends React.Component {
    constructor(props) {
        super(props);
        this._navigate = this._navigate.bind(this);
    }
    _navigate(location) {
        browserHistory.push(`#/${location}`);
    }
    _navigateUrl(location) {
        window.location.href = location;
    }
    render() {
        return(
            <aside>
                <div className="menu--header">
                    Menu
                </div>
                <List selectable ripple>
                    <ListItem leftIcon="home"
                              key="Home"
                              caption="Home"
                              legend="Your dashboard"
                              selectable
                              onClick={() => {this._navigate('notshipped')}} />
                    <ListItem leftIcon="file_upload"
                              key="upload"
                              caption="Upload"
                              legend="Add a new consignment"
                              selectable onClick={() => {this._navigate('upload')}} />
                    <ListItem leftIcon="assignment"
                              key="NotShipped"
                              caption="Not Shipped"
                              legend="View consignments that haven't shipped"
                              selectable
                              onClick={() => {this._navigate('notshipped')}} />
                    <ListItem leftIcon="assignment_turned_in"
                              key="Shipped"
                              caption="Shipped"
                              legend="View consignments that have shipped"
                              selectable
                              onClick={() => {this._navigate('shipped')}} />
                    <ListItem leftIcon="description"
                              key="Manifests"
                              caption="Manifests"
                              legend="View consignment manifests"
                              selectable
                              onClick={() => {this._navigate('manifests')}} />
                    <ListItem leftIcon="search"
                              key="Search"
                              caption="Search"
                              legend="Search for matching consignments"
                              selectable
                              onClick={() => {this._navigate('search')}} />
                    <ListItem leftIcon="insert_chart"
                              key="Reports"
                              caption="Reports"
                              legend="View and manage your reports"
                              selectable
                              onClick={() => {this._navigate('reports')}} />
                    <ListItem leftIcon="account_balance"
                              key="Reconciliation"
                              caption="Reconciliation"
                              legend="Reconcile your carrier invoices"
                              selectable
                              onClick={() => {this._navigate('reconciliation')}} />
                    <ListDivider />
                    <ListSubHeader caption="Account" />
                    <ListItem leftIcon="person" caption="Your Account" onClick={() => {this._navigate('myaccount')}}/>
                    <ListItem leftIcon="exit_to_app" caption="Logout" onClick={() => {this._navigateUrl('account/logout')}}/>
                    
                </List>
            </aside>
        );    
    }
};

SideDrawer.propTypes = {
    router: PropTypes.object
};





//class SideDrawer extends React.Component {
//    constructor(props) {
//        super(props);
//        this._navigate = this._navigate.bind(this);
//    } 
//    _navigate(route) {
//        alert(route);
//        if (route) {
//            browserHistory.push(route);
//        }
//    }
//    render() {
//        return(
//           <div>
//               <div className="menu--header">
//                Menu
//               </div>
//               <MenuItem value='#Upload' icon='file_upload' caption='Upload' onSelect={this._navigate('#/upload')} />
//               <MenuItem value='#Not Shipped' icon='assignment' caption='Not Shipped' />
//               <MenuItem value='#Shipped' icon='assignment_turned_in' caption='Shipped' />
//               <MenuItem value='#Manifests' icon='description' caption='Manifests' />
//               <MenuItem value='#Search' icon='search' caption='Search' />
//               <MenuItem value='#Reports' icon='insert_chart' caption='Reports' />
//               <MenuItem value='#Reconciliation' icon='account_balance' caption='Reconciliation' />
//           </div>
 
//        );
//    }
//}

export default SideDrawer;