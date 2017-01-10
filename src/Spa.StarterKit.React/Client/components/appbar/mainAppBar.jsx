import React, { Component } from 'react';
import { AppBar } from 'react-toolbox';
import { Link } from 'react-router';
//logo?
import theme from './theme.scss';

class MainAppBar extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <AppBar {...this.props} theme={theme} >
                {this.props.children}
            </AppBar>
        );
    }
}

//MainAppBar.propTypes = {
//    className: React.PropTypes.string
//};

//MainAppBar.defaultProps = {
//    className: ''
//}

export default MainAppBar;