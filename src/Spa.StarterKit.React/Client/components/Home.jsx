import React from 'react';
import ReactCssTransitionGroup from 'react-addons-css-transition-group';
import { Link } from 'react-router';
import MainContainer from '../containers/MainContainer';
import SideDrawer from '../components/SideDrawer';
import SiteHeader from '../components/SiteHeader';
import SiteFooter from '../components/SiteFooter';
import MainAppBar from '../components/appbar/mainAppBar';


import { AppBar, Checkbox, IconButton } from 'react-toolbox';
import { Layout, NavDrawer, Panel, Sidebar } from 'react-toolbox';

import 'react-mdl/extra/material.js';
import '../sass/global.scss';

class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            drawerActive: false,
            drawePinned: false,
            sidebarPinned: false
        }
        this.toggleDrawerActive = this.toggleDrawerActive.bind(this);
        this.toggleDrawerPinned = this.toggleDrawerPinned.bind(this);
        this.toggleSidebar = this.toggleSidebar.bind(this);

    }
    toggleDrawerActive() {
        this.setState({ drawerActive: !this.state.drawerActive });
    }
    toggleDrawerPinned() {
        this.setState({ drawerPinned: !this.state.drawerPinned });
    }

    toggleSidebar() {
        this.setState({ sidebarPinned: !this.state.sidebarPinned });
    }

    render() {
        return(
            <Layout>
                <NavDrawer active={this.state.drawerActive}
                           pinned={this.state.drawerPinned}
                           onOverlayClick={ this.toggleDrawerActive }>
                    <SideDrawer toggleDrawer={this.toggleDrawerActive} />
                </NavDrawer>
                <Panel>
                    <MainAppBar onLeftIconClick={this.toggleDrawerActive} leftIcon="menu" />
                        <ReactCssTransitionGroup transitionName="appear"
                                                 transitionEnterTimeout={500}
                                                 transitionLeaveTimeout={500}
                                                 component={MainContainer}>
                            {React.cloneElement(this.props.children, {key: this.props.location.pathname})}
                        </ReactCssTransitionGroup>
                </Panel>
                <Sidebar pinned={ this.state.sidebarPinned } width={ 5 }>
                    <div><IconButton icon='close' onClick={ this.toggleSidebar } /></div>
                    <div style={{ flex: 1 }}>
                        <p>Supplemental content goes here.</p>
                    </div>
                </Sidebar>
            </Layout>

        );
    }
};

export default Home;