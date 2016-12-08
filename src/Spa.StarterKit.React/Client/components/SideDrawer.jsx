import React from 'react';
import { Navigation, Drawer } from 'react-mdl';
import { Link } from 'react-router';

class SideDrawer extends React.Component {
    constructor(props) {
        super(props);
    } 
    render() {
        return(
           <Drawer title="Menu">
            <Navigation>
                <Link to="/">
                    Home
                </Link>
                <Link to="NotShipped">Not Shipped</Link>
                <Link to="Shipped">Shipped</Link>
                <Link to="NewConsignment">New Consignment</Link>
                <Link to="Tracking">Tracking</Link>
            </Navigation>
           </Drawer> 
        );
    }
}

export default SideDrawer;