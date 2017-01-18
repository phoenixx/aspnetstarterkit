import React, { Component } from 'react';
import axios from 'axios';
import Dialog from 'react-toolbox/lib/dialog';
import Input from 'react-toolbox/lib/input';
import Loading from '../components/Loading';
import PageHeader from '../components/layout/pageHeader';
import Utils from '../components/utils/utils';
import StaticData from '../components/utils/staticData';
import { Grid, Cell, Card, CardTitle, CardText } from 'react-mdl';
import Dropdown from 'react-toolbox/lib/dropdown';
import Autocomplete from '../components/autocomplete/autocomplete';
import {Button, IconButton} from 'react-toolbox/lib/button';
import '../sass/consignment.scss';

class ConsignmentContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            consignment: null,
            showAddressDialog: false,
            addressDialogData: null
        }
        this._loadConsignment = this._loadConsignment.bind(this);
        this._toggleAddressDialog = this._toggleAddressDialog.bind(this);
        this._lookups = this._lookups.bind(this);
    }
    componentDidMount() {
        this._loadConsignment().then((result) => {
            this.setState({
                loading: false,
                consignment: result
            });
        });
        this._lookups();
    }
    _toggleAddressDialog(address) {
        if (address && address.addressLine1) {
            this.setState({
                showAddressDialog: !this.state.showAddressDialog,
                addressDialogData: address
            });
        } else {
            this.setState({
                showAddressDialog: false
            });
        }
    }
    _loadConsignment() {
        const url = `/consignment/${this.props.params.consignmentReference}`;

        return axios.get(url).then((result) => {
            console.log(`result from ${url}:`, result);
            return result.data;
        });
    }
    _lookups() {
        return axios.all([
            StaticData.getTitles(),
            StaticData.getCountries()
        ])
        .then(axios.spread((titles, countries) => {
                this.setState({
                    titles: titles,
                    countries: countries
                });
            }));
    }
    render() {
        if (this.state.loading) {
            return (<Loading/>);
        } else {
            const consignmentState = `Consignment status: ${Utils.splitCamelCase(this.state.consignment.consignmentState)}`;
            const origin = this.state.consignment.addresses.filter((address) => {
                return address.addressType === 'Origin';
            });
            const destination = this.state.consignment.addresses.filter((address) => {
                return address.addressType === 'Destination';
            });
            
            return(
                <Grid>
                    <PageHeader title={`Consignment ${this.state.consignment.reference}`}/>
                    <Cell col={3} tablet={12} phone={12}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>Addresses</CardTitle>
                            <CardText className="consignment-card">
                                From: 
                                {Utils.formatConsignmentAddress(origin[0])}
                                <Button icon='create' floating mini onClick={() => this._toggleAddressDialog(origin[0])} />
                                <br/>
                                To:
                                {Utils.formatConsignmentAddress(destination[0])}
                                <Button icon='create' floating mini onClick={() => this._toggleAddressDialog(destination[0])} />
                            </CardText>
                        </Card>
                    </Cell>
                    <Cell col={3}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>Consignment details</CardTitle>
                        </Card>
                    </Cell>
                    <Cell col={6}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>{consignmentState}</CardTitle>
                        </Card>
                    </Cell>

                    <EditAddressDialog 
                        title='Edit address'
                        active={this.state.showAddressDialog}
                        toggleDialog={this._toggleAddressDialog}
                        address={this.state.addressDialogData}
                        countries={this.state.countries}
                        consignmentReference={this.state.consignment.reference} />
                </Grid>
            );    
        }
    }
}

class CountryAutocomplete extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: [this.props.initialValue],
            options: this._mapOptions(this.props.source)
        }
        this._changeValue = this._changeValue.bind(this);
    }
    _mapOptions(options) {
        let countriesObject = {};
        options.map((option) => {
            countriesObject[option.value] = option.label;
        });
        console.log(countriesObject);
        return countriesObject;
    }
    _changeValue(value) {
        debugger;
        this.setState({ selected: value });
        this.props.onChange(value);
    }
    render() {
        return(
            <Autocomplete 
                direction="down"
                label="Choose country"
                source={this.state.options}
                value={this.state.selected}
                multiple={false}
                onChange={this._changeValue}
            />
        );
    }
}

//todo extract...
class CountryDropdown extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selected: this.props.initialValue
        }
        this._customItem = this._customItem.bind(this);
        this._selectItem = this._selectItem.bind(this);
    }
    _selectItem(item) {
        console.log(item);
        this.setState({
            selected: item
        });
    }
    _customItem(item) {
        const containerStyle = {
            display: 'flex',
            flexDirection: 'row'
        }

        const valueStyle = {
            display: 'flex',
            height: '32px',
            width: '32px',
            flexGrow: 0,
            marginRight: '8px',
            backgroundColor: '#ccc',
            textAlign: 'center',
            marginLeft: 0
        }

        const contentStyle = {
            display: 'flex',
            flexDirection: 'column',
            flexGrow: 2
        }

        return(
            <div style={containerStyle}>
                <div style={valueStyle}>
                    {item.value}
                </div>
                <div style={contentStyle}>
                    <strong>{item.label}</strong>
                </div>
            </div>
        );
    }
    render() {
        return(
            <Dropdown auto source={this.props.source} template={this._customItem} value={this.state.selected} onChange={(item) => this._selectItem(item)} />
        );
    }
}

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
            specialInstructions: null
        };

        this.state = address;
        this._saveAddress = this._saveAddress.bind(this);
        this._handleChange = this._handleChange.bind(this);

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
    componentWillReceiveProps(props) {
        const newState = Object.assign({}, props.address);
        this.setState(newState);
    }
    render() {
        return(
            <Dialog active={this.props.active} onEscKeyDown={this.props.toggleDialog} title={this.props.title}>
                {this.props.address === null ? (null) : (
                    <Grid>
                        <Cell col={6}>
                            <Input type='text' label='Title' name='Title' value={this.state.contact.title} onChange={(val) => this._handleChange('contact', 'title', val)} />
                            <Input type='text' label='Forename' name='Forename' value={this.state.contact.firstName} onChange={(val) => this._handleChange('contact', 'firstName', val)}/>
                            <Input type='text' label='Surname' name='Surname' value={this.state.contact.lastName} onChange={(val) => this._handleChange('contact', 'lastName', val)}/>
                            <Input type='text' label='Email' name='Email' value={this.state.contact.email} onChange={(val) => this._handleChange('contact', 'email', val)}/>
                            <Input type='text' label='Landline' name='Landline' value={this.state.contact.landline} onChange={(val) => this._handleChange('contact', 'landline', val)}/>
                            <Input type='text' label='Mobile' name='Mobile' value={this.state.contact.mobile} onChange={(val) => this._handleChange('contact', 'mobile', val)}/>
                        </Cell>
                        <Cell col={6}>
                            <Input type='text' label='Address Line 1' name='Address Line 1' value={this.state.addressLine1} onChange={(val) => this._handleChange(null, 'addressLine1', val)}/>
                            <Input type='text' label='Address Line 2' name='Address Line 2' value={this.state.addressLine2} onChange={(val) => this._handleChange(null, 'addressLine2', val)}/>
                            <Input type='text' label='Address Line 3' name='Address Line 3' value={this.state.addressLine3} onChange={(val) => this._handleChange(null, 'addressLine3', val)}/>
                            <Input type='text' label='Town' name='Town' value={this.state.town} onChange={(val) => this._handleChange(null, 'town', val)}/>
                            <Input type='text' label='Region' name='Region' value={this.state.region} onChange={(val) => this._handleChange(null, 'region', val)}/>
                            <Input type='text' label='Postcode' name='Postcode' value={this.state.postcode} onChange={(val) => this._handleChange(null, 'postcode', val)}/>
                            <CountryAutocomplete initialValue={this.state.country.isoCode.twoLetterCode} source={this.props.countries} onChange={(val) => { this._handleChange('country.isoCode', 'twoLetterCode', val); }}/>
                            <Input type='text' label='Special instructions' name='Special instructions' value={this.state.specialInstructions} onChange={(val) => this._handleChange(null, 'specialInstructions', val)} />
                        </Cell>
                        <Cell col={12} style={{textAlign: 'right'}}>
                            <Button icon='clear' label='Cancel' flat primary onClick={this.props.toggleDialog} />
                            <Button icon='done' label='Save' raised primary onClick={this._saveAddress} />
                        </Cell>
                    </Grid>
                )}
            </Dialog>
);
}
}

export default ConsignmentContainer;
