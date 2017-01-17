import React, { Component, PropTypes } from 'react';
import '../../sass/pageHeader.scss';
import { Cell } from 'react-mdl';

class PageHeader extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        return(
            <Cell col={12}>
                <h2>{this.props.title}</h2>
                {this.props.subtitle ? (<h3>{this.props.subtitle}</h3>): (null)}
            </Cell>
        );
    }
}

PageHeader.propTypes = {
    title: PropTypes.string.required,
    subtitle: PropTypes.string
}

export default PageHeader;