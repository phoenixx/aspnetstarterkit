import React, { Component } from 'react';
import { Tabs as ReactTabs } from 'react-toolbox';
import Theme from './theme.scss';

class Tabs extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(<ReactTabs {...this.props} theme={Theme}>{this.props.children}</ReactTabs>);
    }
}

export default Tabs;