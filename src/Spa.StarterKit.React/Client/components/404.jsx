import React, { Component } from 'react';
import '../sass/404.scss';

class RouteNotFound extends Component {
    constructor(props) {
        super(props);
    }
    render() {
        const attemptedRoute = this.props.params.splat;
        return(
            <div className="notfound--container">
                Dude, that page no existio
                <div className="notfound--subtext">
                    Page '{attemptedRoute}' is not currently in existence.
                </div>
            </div>
        );
    }
}

export default RouteNotFound;