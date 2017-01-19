import React, { Component } from 'react';
import '../sass/address.scss';

class AddressDisplayContainer extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <div>
                <div className="vcard">
                    <span className="honorific-prefix">
                        {this.props.address.contact.title}
                    </span>
                    <span className="given-name">
                        {this.props.address.contact.firstName}
                    </span>
                    <span className="family-name">
                        {this.props.address.contact.lastName}
                    </span>
                    {this.props.address.contact.email ? (<span className="email">({this.props.address.contact.email})</span>) : (null)}
                </div>
                <div className="adr">
                    <div className="street-address">
                        {this.props.address.addressLine1}
                    </div>
                    <div className="locality">
                        {this.props.address.town}
                    </div>
                    <div className="region">
                        {this.props.address.region}
                    </div>
                    <div className="postal-code">
                        {this.props.address.postcode}
                    </div>
                    <div className="country-name">
                        {this.props.address.country.name}
                    </div>
                </div>
            </div>
        );
    }
}

export { AddressDisplayContainer }