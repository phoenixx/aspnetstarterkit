import React from 'react';
//import { Header, Navigation } from 'react-mdl';
import { AppBar } from 'react-toolbox/lib/app_bar';
import Navigation from 'react-toolbox/lib/navigation';
import Link from 'react-toolbox/lib/Link';

import stylePropType from 'react-style-proptype'

class SiteHeader extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <AppBar title="Electio" leftIcon="menu" fixed="true">
                <Navigation type='horizontal'>
                  <Link href='/Logout' label='Logout' icon='exit_to_app' />
                </Navigation>
            </AppBar>
            
        );
    }
}

SiteHeader.propTypes = {
    title: React.PropTypes.string,
    className: React.PropTypes.string,
    style: stylePropType
}

SiteHeader.defaultProps = {
    title: 'Electio',
    className: 'electio-color--red',
    style: {color: 'white'}
}

export default SiteHeader;