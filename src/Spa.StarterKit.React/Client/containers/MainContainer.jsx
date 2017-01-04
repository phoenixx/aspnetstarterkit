import React, { Component } from 'react';
import { Grid, Layout } from 'react-mdl';

class MainContainer extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div style={{ flex: 1, overflowY: 'auto', padding: '1.8rem' }}>
                {this.props.children}
            </div>
        );    
    }
};

export default MainContainer;