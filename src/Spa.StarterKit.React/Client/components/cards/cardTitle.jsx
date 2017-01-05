import React, { Component } from 'react';
import { CardTitle } from 'react-toolbox/lib/card';
import Theme from './cardTitleTheme.scss';

class MpdCardTitle extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <CardTitle {...this.props} theme={Theme}/>    
        );
    }
}

export default MpdCardTitle;