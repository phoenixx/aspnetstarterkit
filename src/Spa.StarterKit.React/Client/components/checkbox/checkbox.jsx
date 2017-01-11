import React, { Component } from 'react';
import { Checkbox as MaterialCheckbox }from 'react-toolbox/lib/checkbox';
import Theme from './theme.scss';

class Checkbox extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(<MaterialCheckbox {...this.props} theme={Theme}/>);
    }
}

export default Checkbox;