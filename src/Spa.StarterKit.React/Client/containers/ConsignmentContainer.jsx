import React, { Component } from 'react';
import axios from 'axios';
import Loading from '../components/Loading';
import StaticData from '../components/utils/staticData';
import ConsignmentView from '../components/consignments/consignmentView';

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
            const origin = this.state.consignment.addresses.filter((address) => {
                return address.addressType === 'Origin';
            });
            const destination = this.state.consignment.addresses.filter((address) => {
                return address.addressType === 'Destination';
            });

            return(
                <ConsignmentView
                    consignment={this.state.consignment}
                    origin={origin[0]}
                    destination={destination[0]}
                    toggleAddressDialog={this._toggleAddressDialog}
                    setActiveTab={this._setActiveTab}
                    showAddressDialog={this.state.showAddressDialog}
                    addressDialogData={this.state.addressDialogData}
                    countries={this.state.countries}
                    shippingLocations={this.state.shippingLocations}
                    activeTab={this.state.activeTab}
                />
            );
        }
    }
}

export default ConsignmentContainer;