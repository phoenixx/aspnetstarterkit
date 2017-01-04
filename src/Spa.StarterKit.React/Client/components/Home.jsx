import React from 'react';
import ReactCssTransitionGroup from 'react-addons-css-transition-group';
import {
    Layout,
    Header,
    HeaderRow,
    Navigation,
    Drawer,
    Content,
    Grid,
    Cell,
    Footer,
    FooterSection,
    FooterDropDownSection,
    FooterLinkList } from 'react-mdl';
import { Link } from 'react-router';
import MainContainer from '../containers/MainContainer';
import SideDrawer from '../components/SideDrawer';
import SiteHeader from '../components/SiteHeader';
import SiteFooter from '../components/SiteFooter';
import '../sass/global.scss';

import 'react-mdl/extra/material.js';

class Home extends React.Component {
    render() {
        return(
            <div>
                <Layout fixedHeader>
                    <SiteHeader title="Electio"/>
                    <SideDrawer/>
                    <Content>
                        <ReactCssTransitionGroup transitionName="appear"
                                                 transitionEnterTimeout={500}
                                                 transitionLeaveTimeout={500}
                                                 component={MainContainer}>{React.cloneElement(this.props.children, {key: this.props.location.pathname})}
                        </ReactCssTransitionGroup>
                    </Content>
                    <SiteFooter size="mini">
                      <a href="#">Help</a>
                      <a href="#">Privacy &amp; Terms</a>
                    </SiteFooter>
                </Layout>
            </div>
        );
    }
};

export default Home;