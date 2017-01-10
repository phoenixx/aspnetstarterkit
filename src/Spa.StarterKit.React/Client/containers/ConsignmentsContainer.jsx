import React, { Component } from 'react';
import axios from 'axios';

class ConsignmentsContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: null
        }
        this._loadData = this._loadData.bind(this);
    }
    componentDidMount() {
        console.log('route data : ' + this.props.route);
        this._loadData(this.props.route.consignmentState).then((data) => {
            this.setState({
                data: data
            });
        }).then(() => {
            console.log(this.state);
        });
    }
    _loadData(state, take, skip) {
        debugger;
        const baseUrl = `/consignments/${state.toLowerCase()}`;

        //add take skip....

        console.log('getting data from ' + baseUrl);

        return axios.get(baseUrl)
            .then(function(response) {
                return response.data;
            });
    }
    render() {
        return(<div>showing data for {this.props.state} consignments</div>);
    }
}

//const loadData = (state, take, skip) => {
//    const baseUrl = `/consignments/${state.toLowerCase()}`;

//    //add take skip....

//    console.log('getting data from ' + baseUrl);

//    return axios.get(baseUrl)
//        .then(function(response) {
//            console.log(response);
//            return response;
//        });
//}

ConsignmentsContainer.propTypes = {
    state: React.PropTypes.string
}

ConsignmentsContainer.defaultProps = {
    state: 'NotShipped'
}

export default ConsignmentsContainer;