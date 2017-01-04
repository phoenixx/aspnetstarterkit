import React from 'react';
import ReactCssTransitionGroup from 'react-addons-css-transition-group';
//import {
//    Layout,
//    Header,
//    HeaderRow,
//    Navigation,
//    Drawer,
//    Content,
//    Grid,
//    Cell,
//    Footer,
//    FooterSection,
//    FooterDropDownSection,
//    FooterLinkList } from 'react-mdl';
import { Link } from 'react-router';
import MainContainer from '../containers/MainContainer';
import SideDrawer from '../components/SideDrawer';
import SiteHeader from '../components/SiteHeader';
import SiteFooter from '../components/SiteFooter';


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
                    <SideDrawer/>
                </NavDrawer>
                <Panel>
                    <AppBar leftIcon='menu' onLeftIconClick={ this.toggleDrawerActive }/>
                    <div style={{ flex: 1, overflowY: 'auto', padding: '1.8rem' }}>
                        <ReactCssTransitionGroup transitionName="appear"
                                                 transitionEnterTimeout={500}
                                                 transitionLeaveTimeout={500}
                                                 component={MainContainer}>{React.cloneElement(this.props.children, {key: this.props.location.pathname})}
                        </ReactCssTransitionGroup>
                    </div>
                </Panel>
                <Sidebar pinned={ this.state.sidebarPinned } width={ 5 }>
                    <div><IconButton icon='close' onClick={ this.toggleSidebar }/></div>
                    <div style={{ flex: 1 }}>
                        <p>Supplemental content goes here.</p>
                    </div>
                </Sidebar>
            </Layout>
           
        );
    }
};

export default Home;