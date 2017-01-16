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
        this.context.router.push(url);
    }
    render() {
        
        return(
            <div className="timeline--container">
                <ol className="timeline--list">
                    {this.props.data.map((header) => {
                        const className = `timeline--badge ${header.severity}`;
                        return(
                                <li>
                                    <div className="timeline--inner" onClick={() => this._clickHandler(header.url)}>
                                        <Link to={header.url}>
                                            {header.label}
                                        </Link>
                                        <span className={className}>{header.numerator}</span>
                                    </div>
                                </li>
                        );
                    })}
                </ol>
            </div>
        );
    }
}

//ConsignmentStateHeaders.propTypes = {
//    data: PropTypes.isArray.required
//}
ConsignmentStateHeaders.contextTypes = {
    router: PropTypes.func.isRequired //force router into context...
}

export default ConsignmentStateHeaders;