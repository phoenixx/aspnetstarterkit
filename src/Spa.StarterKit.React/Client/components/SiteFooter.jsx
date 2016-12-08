import React from 'react';
import {
    Footer,
    FooterSection,
    FooterDropDownSection,
    FooterLinkList } from 'react-mdl';

let currentYear = new Date().getFullYear();

class SiteFooter extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Footer size={this.props.size}>
                <FooterSection type="left" logo={this.props.title}>
                    <FooterLinkList>
                        {this.props.children}
                    </FooterLinkList>
                </FooterSection>
            </Footer>
        );
    }
}

SiteFooter.propTypes = {
    size: React.PropTypes.oneOf(['mini', 'mega']),
    title: React.PropTypes.string

}

SiteFooter.defaultProps = {
    size: 'mini',
    title: `Electio © ${currentYear}`
}

export default SiteFooter;