import React, {Component} from 'react';
import { Autocomplete as ReactAutoComplete } from 'react-toolbox/lib/autocomplete';
import Theme from './theme.scss';

class Autocomplete extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (<ReactAutoComplete {...this.props} theme={Theme}/>);
    }
}

export default Autocomplete;