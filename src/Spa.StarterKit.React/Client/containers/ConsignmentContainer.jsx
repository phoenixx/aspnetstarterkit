import React, { Component } from 'react';
import axios from 'axios';
import Dialog from 'react-toolbox/lib/dialog';
import Input from 'react-toolbox/lib/input';
import Loading from '../components/Loading';
import PageHeader from '../components/layout/pageHeader';
import Utils from '../components/utils/utils';
import StaticData from '../components/utils/staticData';
import Tabs from '../components/tabs/tabs';
import { Tab } from 'react-toolbox';
import { ShortDate, DateTime } from '../components/utils/dateFormatting';
import { AddressDisplayContainer } from './AddressContainer';
import { Grid, Cell, Card, CardTitle, CardText } from 'react-mdl';
import { FormattedNumber } from 'react-intl'; //todo extract to utility component
import Dropdown from 'react-toolbox/lib/dropdown';
import FontIcon from 'react-toolbox/lib/font_icon';
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
            addressDialogData: null,
            activeTab: 0
        }
        this._setActiveTab = this._setActiveTab.bind(this);
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
    _setActiveTab(tabId) {
        this.setState({ activeTab: tabId });
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
            StaticData.getCountries(),
            StaticData.getAssignedShippingLocations()
        ])
        .then(axios.spread((titles, countries, shippingLocations) => {
            this.setState({
                titles: titles,
                countries: countries,
                shippingLocations: shippingLocations
            });
        }));
    }
    render() {
        if (this.state.loading) {
            return (<Loading />);
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
                    <PageHeader title={`Consignment ${this.state.consignment.reference}`} />
                    <Cell col={3} tablet={12} phone={12}>
                        <Grid style={{margin: 0, padding: 0}}>
                            <Cell col={12} style={{margin:0, padding:0, width: '100%', marginBottom: '8px'}}>
                                <Card shadow={0} raised style={{height: '242px', width: '100%'}}>
                                <CardTitle>
                                    <h2>
                                        From
                                    </h2>
                                    <span style={{right:'16px', position: 'absolute'}}>
                                        <Button icon='create' label='Edit' primary onClick={() => this._toggleAddressDialog(origin[0])} />
                                    </span>
                                </CardTitle>
                                <CardText className="consignment-card">
                                    <AddressDisplayContainer address={origin[0]} />
                                </CardText>
                                </Card>
                            </Cell>
                            <Cell col={12} style={{margin:0, padding:0, width: '100%', marginTop: '8px'}}>
                                <Card shadow={0} raised style={{height: '242px', width: '100%'}}>
                                <CardTitle>
                                    <h2>
                                        To
                                    </h2>
                                    <span style={{right:'16px', position: 'absolute'}}>
                                        <Button icon='create' label='Edit' primary onClick={() => this._toggleAddressDialog(destination[0])} />
                                    </span>
                                </CardTitle>
                                <CardText className="consignment-card">
                                    <AddressDisplayContainer address={destination[0]} />
                                </CardText>
                                </Card>
                            </Cell>
                        </Grid>
                    </Cell>
                    <Cell col={3} tablet={12} phone={12}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>
                                <h2>
                                    Consignment details
                                </h2>
                                <span style={{right:'16px', position: 'absolute'}}>
                                    <Button icon='create' label='Edit' primary />
                                </span>
                            </CardTitle>
                            <CardText className="consignment-card">
                                <ConsignmentProperty label="Electio reference">
                                    {this.state.consignment.reference}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Your reference">
                                    {this.state.consignment.consignmentReferenceProvidedByCustomer}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Source">
                                    {this.state.consignment.source}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Shipping Terms">
                                    {this.state.consignment.shippingTerms}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Date created">
                                    <DateTime value={this.state.consignment.dateCreated} />
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Requested delivery date">
                                    {this.state.consignment.requestedDeliveryDate ? (<ShortDate value={this.state.consignment.requestedDeliveryDate.date} />) : (null)}
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Shipping date">
                                    <ShortDate value={this.state.consignment.shippingDate} />
                                </ConsignmentProperty>
                                <ConsignmentProperty label="Earliest delivery">
                                    <ShortDate value={this.state.consignment.earliestDeliveryDate} />
                                </ConsignmentProperty>
                            </CardText>
                        </Card>
                    </Cell>
                    <Cell col={6} tablet={12} phone={12}>
                        <Card shadow={0} raised style={{height: '500px', width: '100%'}}>
                            <CardTitle>
                                <ConsignmentStatusHeader {...this.state.consignment} />
                            </CardTitle>
                            <CardText>
                                <AllocationDetails {...this.state.consignment} />
                            </CardText>
                        </Card>
                    </Cell>
                    <Cell col={12}>
                        <Tabs index={this.state.activeTab} onChange={(tabId) =>this._setActiveTab(tabId)} fixed>
                            <Tab label="Packages" icon="card_giftcard">
                                <PackagesTab packages={this.state.consignment.packages} />
                            </Tab>

                            <Tab label="Documents" icon="description">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Documents & labels</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="Tracking" icon="event">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Tracking events</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="History" icon="history">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>History</CardTitle>
                                </Card>
                            </Tab>
                            <Tab label="Metadata" icon="hourglass_empty">
                                <Card shadow={0} raised style={{height: '300px', width: '100%'}}>
                                    <CardTitle>Metadata</CardTitle>
                                </Card>
                            </Tab>
                        </Tabs>
                    </Cell>
                    <EditAddressDialog title='Edit address'
                                       active={this.state.showAddressDialog}
                                       toggleDialog={this._toggleAddressDialog}
                                       address={this.state.addressDialogData}
                                       countries={this.state.countries}
                                       consignmentReference={this.state.consignment.reference}
                                       shippingLocations={this.state.shippingLocations} />
                </Grid>
            );
        }
    }
}

class ConsignmentStatusHeader extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const consignmentState = `Consignment status: ${Utils.splitCamelCase(this.props.consignmentState)}`;
        return(
            <h2>
                {consignmentState}
                {this.props.isLate ? (<span className="late-icon"><FontIcon value='alarm' /> Late</span>) : (null)}
            </h2>
        );
    }
}

/*extract all this stuff to new components*/
class AllocationDetails extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const inTransition = this.props.consignmentState.substring(this.props.consignmentState.length, 3) === "ing";
        const isAllocated = this.props.allocation !== null && this.props.consignmentState !== "Unallocated" && !inTransition;
        const allocFailed = !isAllocated && this.props.failedAllocation !== null;

        return (<Actions {...this.props} />);

        //if (isAllocated) {
        //    return (<AllocatedPanel {...this.props.allocation} />);
        //}

        //if (allocFailed) {
        //    return (<div>failed</div>);
        //}

        //return(<div>default</div>);


    }
}

class Actions extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const inTransition = this.props.consignmentState.substring(this.props.consignmentState.length, 3) === "ing";

        const isAllocated = this.props.allocation !== null && this.props.consignmentState !== "Unallocated" && !inTransition;
        const allocFailed = !isAllocated && this.props.failedAllocation !== null;
        return(
            <div>
                <div className="panel">
                    <span className="panel--action">Available actions:</span>
                    <ConditionalComponent condition={() => isAllocated === false && inTransition === false}>
                        <Button icon='done' label='Allocate' raised primary className="button--action" />
                    </ConditionalComponent>
                    <ConditionalComponent condition={() => isAllocated === true}>
                        <Button icon='cancel' label='De-allocate' raised primary className="button--action" />
                        <Button icon='assignment' label='Manifest' raised primary className="button--action" />
                        <Button icon='print' label='Print labels' raised primary className="button--action" />
                    </ConditionalComponent>
                </div>
                {isAllocated === true ? (
                    <div className="panel">
                        <span className="panel--title">Allocation details</span>
                        <AllocationProperty label="Service Name">
                            {this.props.allocation.mpdCarrierServiceName}
                        </AllocationProperty>
                        <AllocationProperty label="Service Code">
                            {this.props.allocation.mpdCarrierServiceReference}
                        </AllocationProperty>
                        <AllocationProperty label="Price">
                            <FormattedNumber value={this.props.allocation.price.net} style="currency" currency={this.props.allocation.price.currency.isoCode} />
                        </AllocationProperty>
                    </div>
                ) : (null)}
                {allocFailed ? (
                    <div className="panel">
                        <span className="panel--title">Allocation failure details</span>
                        <div className="allocation-failure-message">
                            <AllocationProperty label="Attempted allocation">
                                <DateTime value={this.props.failedAllocation.attemptedAllocationDate} />
                            </AllocationProperty>
                            <AllocationProperty label="Allocation failure reason">
                                {this.props.failedAllocation.message}
                            </AllocationProperty>
                        </div>
                    </div>
                ) : (null)}
                <span className="cancel-link">
                    <a href="#/">Cancel consignment</a>
                </span>
            </div>
        );
    }
}

class ConditionalComponent extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const doRender = this.props.condition();
        console.log(doRender);
        if (doRender === true) {
            return(<span>{this.props.children}</span>);
        } else {
            return null;
        }
    }
}

class AllocatedPanel extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div>
                <div className="panel">
                    <span className="panel--action">Available actions:</span>
                    <Button icon='cancel' label='De-allocate' raised primary className="button--action" />
                    <Button icon='assignment' label='Manifest' raised primary className="button--action" />
                    <Button icon='print' label='Print labels' raised primary className="button--action" />
                </div>
                <div className="panel">
                    <span className="panel--title">Allocation details</span>
                    <AllocationProperty label="Service Name">
                        {this.props.mpdCarrierServiceName}
                    </AllocationProperty>
                    <AllocationProperty label="Service Code">
                        {this.props.mpdCarrierServiceReference}
                    </AllocationProperty>
                    <AllocationProperty label="Price">
                        <FormattedNumber value={this.props.price.net} style="currency" currency={this.props.price.currency.isoCode} />
                    </AllocationProperty>
                </div>
                <span className="cancel-link">
                    <a href="#/">Cancel consignment</a>
                </span>
            </div>

        );
    }
}

class PackagesTab extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Card shadow={0} raised style={{minHeight: '300px', width: '100%'}}>
                <CardTitle>Packages</CardTitle>
                <CardText className="tab--cardtext">
                    {this.props.packages.map((pkg) => {
                        return (<Package {...pkg} />);
                    })}
                </CardText>
            </Card>
        );
    }
}

class Package extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="package-container">
                <div className="package-reference">
                    Package {this.props.reference}
                </div>
                <div className="package-edit">
                        <Button icon='create' label='Edit' primary />
                </div>
                <table className="package-table">
                    <thead>
                        <tr>
                            <th>Your reference</th>
                            <th>Description</th>
                            <th>Dimensions</th>
                            <th>Value</th>
                            <th>Barcode</th>

                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <OptionalProperty>
                                    {this.props.packageReferenceProvidedByCustomer}
                                </OptionalProperty>
                            </td>
                            <td>{this.props.description}</td>
                            <td>{this.props.dimensions.height}cm x {this.props.dimensions.length}cm x {this.props.dimensions.width}cm</td>
                            <td><FormattedNumber value={this.props.value.amount} style="currency" currency={this.props.value.currency.isoCode} /></td>
                            <td>
                                <OptionalProperty>
                                    {this.props.barcode}
                                </OptionalProperty>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }
}

class AllocationProperty extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="property-group">
                <span className="property-group__label--narrow">
                    {this.props.label}:
                </span>
                <OptionalProperty>
                    {this.props.children}
                </OptionalProperty>
            </div>
        );
    }
}

class ConsignmentProperty extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div className="property-group">
                <span className="property-group__label">
                    {this.props.label}:
                </span>
                <OptionalProperty>
                    {this.props.children}
                </OptionalProperty>
            </div>
        );
    }
}

class OptionalProperty extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <span className="property-group__item">
                {(this.props.children && this.props.children !== '') ?
                (this.props.children)
                :
                (<span className="property-group__item--empty">Not specified</span>)}
            </span>
        );
    }
}

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
            console.log(match);
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

export default ConsignmentContainer;
