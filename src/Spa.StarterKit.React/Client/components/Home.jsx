import React from 'react';
import ReactCssTransitionGroup from 'react-addons-css-transition-group';
import {
    Layout,
    Header,
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

import 'react-mdl/extra/material.css';
import 'react-mdl/extra/material.js';

class Home extends React.Component {
    render() {
        return(
            <div>
                <Layout>
                    <Header title="Electio" style={{color: 'white'}}>
                        <Navigation>
                            <Link to="/login">
                            Login
                            </Link>
                        </Navigation>
                    </Header>
                    <Drawer title="Menoo">
                        <Navigation>
                            <a href="">Home</a>
                            <a href="">Not Shipped</a>
                            <a href="">Shipped</a>
                            <a href="">New Consignment</a>
                            <a href="">Tracking</a>
                        </Navigation>
                    </Drawer>
                    <Content>
                        <ReactCssTransitionGroup transitionName="appear"
                                                 transitionEnterTimeout={500}
                                                 transitionLeaveTimeout={500}
                                                 component={MainContainer}>{React.cloneElement(this.props.children, {key: this.props.location.pathname})}
                        </ReactCssTransitionGroup>
                    </Content>
                    <Footer size="mini">
                        <FooterSection type="left" logo="Electio">
                            <FooterLinkList>
                                <a href="#">Help</a>
                                <a href="#">Privacy &amp; Terms</a>
                            </FooterLinkList>
                        </FooterSection>
                    </Footer>
                </Layout>
            </div>
        );
    }
};

export default Home;