import React, { Component } from 'react';
import { Button } from 'react-toolbox/lib/button';
import Theme from './redtheme.scss';

class RedButton extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Button {...this.props} theme={Theme}>
                {this.props.children}
            </Button>
        );
    }
}

export default RedButton;