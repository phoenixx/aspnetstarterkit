import React, { Component, PropTypes } from 'react';
import { Link } from 'react-router';
import '../../sass/consignmentStatesHeader.scss';

class ConsignmentStateHeaders extends Component {
    constructor(props) {
        super(props);
        this._clickHandler = this._clickHandler.bind(this);
    }
    _clickHandler(url) {
        console.log(url);
    }
    render() {
        return(
            <div className="timeline--container">
                <div className="timeline--list">
                    {this.props.data.map((header) => {
                        return(
                            <div className="timeline--inner" onClick={(h) => this._clickHandler(h.url)}>
                                <Link to={header.url}>
                                    {header.label}
                                </Link>
                                <span className="timeline--badge">{header.numerator}</span>
                            </div>
                        );
                    })}
                </div>
            </div>
        );
    }
}

//ConsignmentStateHeaders.propTypes = {
//    data: PropTypes.isArray.required
//}

export default ConsignmentStateHeaders;