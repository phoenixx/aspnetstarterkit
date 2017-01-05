import React, { Component } from 'react';
import { Grid, Layout } from 'react-mdl';

class MainContainer extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="main-container">
                {this.props.children}
            </div>
        );    
    }
};

export default MainContainer;