import React, { Component } from 'react';
import Autocomplete from '../autocomplete/autocomplete';

class CountryAutocomplete extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: [this.props.initialValue],
            options: this._mapOptions(this.props.source)
        }
    }
    _mapOptions(options) {
        let countriesObject = {};
        options.map((option) => {
            countriesObject[option.value] = option.label;
        });
        return countriesObject;
    }
    render() {
        return(
            <Autocomplete disabled={this.props.disabled}
                direction="down"
                label="Choose country"
                source={this.state.options}
                value={this.props.value}
                onChange={this.props.onChange}
                multiple={false} />
        );
    }
}

export default CountryAutocomplete;