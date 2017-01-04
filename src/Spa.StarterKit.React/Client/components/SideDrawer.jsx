import React from 'react';
import { Navigation, Drawer } from 'react-mdl';
import { Link } from 'react-router';

import { IconMenu, MenuItem, MenuDivider} from 'react-toolbox/lib/menu';

class SideDrawer extends React.Component {
    constructor(props) {
        super(props);
    } 
    render() {
        return(
           <div>
               <MenuItem value='Not Shipped' icon='assignment' caption='Not Shipped' />
               <MenuItem value='Shipped' icon='assignment_turned_in' caption='Shipped' />
               <MenuItem value='Manifests' icon='description' caption='Manifests' />
               <MenuItem value='Search' icon='search' caption='Search' />
               <MenuItem value='Reports' icon='insert_chart' caption='Reports' />
               <MenuItem value='Reconciliation' icon='account_balance' caption='Reconciliation' />
           </div>
 
        );
    }
}

export default SideDrawer;