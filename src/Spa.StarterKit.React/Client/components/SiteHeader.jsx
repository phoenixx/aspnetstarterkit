import React from 'react';
import { Header } from 'react-mdl';
import stylePropType from 'react-style-proptype'

class SiteHeader extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Header 
                title={this.props.title}
                className={this.props.className}
                style={this.props.style}>
                {this.props.children}
             </Header>
        );
    }
}

SiteHeader.propTypes = {
    title: React.PropTypes.string,
    className: React.PropTypes.string,
    style: stylePropType
}

SiteHeader.defaultProps = {
    title: 'Electio',
    className: 'mdl-color--orange-900',
    style: {color: 'white'}
}

export default SiteHeader;