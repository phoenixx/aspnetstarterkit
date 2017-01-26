import React, { Component } from 'react';
import Utils from '../utils/utils';
import Dialog from 'react-toolbox/lib/dialog';
import { Grid, Cell, Card, CardTitle, CardText } from 'react-mdl';
import Input from 'react-toolbox/lib/input';
import Dropdown from 'react-toolbox/lib/dropdown';
import { Button } from 'react-toolbox/lib/button';
import CountryAutocomplete from '../common/countryAutocomplete';

class EditAddressDialog extends Component {
    constructor(props) {
        super(props);
        let address = this.props.address != null ? this.props.address : {
            contact: {
                title: null,
                firstName: null,
                lastName: null,
                email: null,
                landline: null,
                mobile: null
            },
            addressLine1: null,
            addressLine2: null,
            addressType: null,
            country: {
                name: null,
                isoCode: {
                    twoLetterCode: null
                }
            },
            postcode: null,
            region: null,
            specialInstructions: null,
            shippingLocationReference: null
        };
        this.state = address;
        this._saveAddress = this._saveAddress.bind(this);
        this._handleChange = this._handleChange.bind(this);
        this._handleShippingLocationSelect = this._handleShippingLocationSelect.bind(this);
        this._shippingLocationExists = this._shippingLocationExists.bind(this);
        this._clearShippingLocation = this._clearShippingLocation.bind(this);
    }
    _saveAddress() {
        const url = `/consignment/${this.props.consignmentReference}/updateaddress`;
        console.log(this.state);
    }
    _handleChange(parentName, objName, objValue) {
        if (parentName) {
            const modifiedField = Utils.setNestedPropertyValue(this.state, parentName, objName, objValue);
            this.setState({ [parentName]: modifiedField });
        } else {
            this.setState({ [objName]: objValue });
        }
    }
    _handleShippingLocationSelect(locationRef) {

        const loc = this.props.shippingLocations.filter((loc) => {
            return loc.value === locationRef;
        });
        const empty = '';
        if (loc.length > 0) {
            const match = loc[0].location;
            this.setState({
                contact: {
                    title: match.contact.title || empty,
                    firstName: match.contact.firstName || empty,
                    lastName: match.contact.lastName || empty,
                    email: match.contact.email || empty,
                    landline: match.contact.landline || empty,
                    mobile: match.contact.mobile || empty
                },
                addressLine1: match.addressLine1 || empty,
                addressLine2: match.addressLine2 || empty,
                country: {
                    name: match.country.name || empty,
                    isoCode: {
                        twoLetterCode: match.country.isoCode.twoLetterCode || empty
                    }
                },
                postcode: match.postcode || empty,
                region: match.region || empty,
                specialInstructions: match.specialInstructions || empty,
                shippingLocationReference: locationRef
            });
        }
    }
    _clearShippingLocation() {
        this.setState({ shippingLocationReference: null });
    }
    _shippingLocationExists() {
        const locationRef = this.state.shippingLocationReference;
        const loc = this.props.shippingLocations.filter((loc) => {
            return loc.value === locationRef;
        });
        return (typeof loc !== 'undefined' && loc !== null && loc.length > 0);
    }
    componentWillReceiveProps(props) {
        const newState = Object.assign({}, props.address);
        this.setState(newState);
    }

    render() {
        const inputDisabled = this.state && this.state.shippingLocationReference !== null && this._shippingLocationExists();
        return(
            <Dialog active={this.props.active} onEscKeyDown={this.props.toggleDialog} onOverlayClick={this.props.toggleDialog} title={this.props.title}>
                {this.props.address === null ? (null) : (
                <Grid>
                    <Cell col={6}>
                        <Dropdown label='Shipping Location' auto source={this.props.shippingLocations} value={this.state.shippingLocationReference} onChange={(val) => this._handleShippingLocationSelect(val)} />
                        <Input disabled={inputDisabled} type='text' label='Title' name='Title' value={this.state.contact.title} onChange={(val) => this._handleChange('contact', 'title', val)} />
                        <Input disabled={inputDisabled} type='text' label='Forename' name='Forename' value={this.state.contact.firstName} onChange={(val) => this._handleChange('contact', 'firstName', val)} />
                        <Input disabled={inputDisabled} type='text' label='Surname' name='Surname' value={this.state.contact.lastName} onChange={(val) => this._handleChange('contact', 'lastName', val)} />
                        <Input disabled={inputDisabled} type='text' label='Email' name='Email' value={this.state.contact.email} onChange={(val) => this._handleChange('contact', 'email', val)} />
                        <Input disabled={inputDisabled} type='text' label='Landline' name='Landline' value={this.state.contact.landline} onChange={(val) => this._handleChange('contact', 'landline', val)} />
                        <Input disabled={inputDisabled} type='text' label='Mobile' name='Mobile' value={this.state.contact.mobile} onChange={(val) => this._handleChange('contact', 'mobile', val)} />
                    </Cell>
                    <Cell col={6}>
                        <Input disabled={inputDisabled} type='text' label='Address Line 1' name='Address Line 1' value={this.state.addressLine1} onChange={(val) => this._handleChange(null, 'addressLine1', val)} />
                        <Input disabled={inputDisabled} type='text' label='Address Line 2' name='Address Line 2' value={this.state.addressLine2} onChange={(val) => this._handleChange(null, 'addressLine2', val)} />
                        <Input disabled={inputDisabled} type='text' label='Address Line 3' name='Address Line 3' value={this.state.addressLine3} onChange={(val) => this._handleChange(null, 'addressLine3', val)} />
                        <Input disabled={inputDisabled} type='text' label='Town' name='Town' value={this.state.town} onChange={(val) => this._handleChange(null, 'town', val)} />
                        <Input disabled={inputDisabled} type='text' label='Region' name='Region' value={this.state.region} onChange={(val) => this._handleChange(null, 'region', val)} />
                        <Input disabled={inputDisabled} type='text' label='Postcode' name='Postcode' value={this.state.postcode} onChange={(val) => this._handleChange(null, 'postcode', val)} />
                        <CountryAutocomplete disabled={inputDisabled} initialValue={this.state.country.isoCode.twoLetterCode} value={this.state.country.isoCode.twoLetterCode} source={this.props.countries} onChange={(val) => { this._handleChange('country.isoCode', 'twoLetterCode', val); }} />
                        <Input disabled={inputDisabled} type='text' label='Special instructions' name='Special instructions' value={this.state.specialInstructions} onChange={(val) => this._handleChange(null, 'specialInstructions', val)} />
                    </Cell>
                    <Cell col={12} style={{textAlign: 'right'}}>
                        <Button disabled={!inputDisabled} icon='block' label='Clear shipping location' flat primary onClick={this._clearShippingLocation} />
                        &nbsp;
                        <Button icon='clear' label='Cancel' flat primary onClick={this.props.toggleDialog} />
                        &nbsp;
                        <Button icon='done' label='Save' raised primary onClick={this._saveAddress} />
                    </Cell>
                </Grid>
                )}
            </Dialog>
        );
    }
}

export default EditAddressDialog;